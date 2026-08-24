using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.Repository;
using Portfolio.DataAccess.Repository.IRepository;
using Portfolio.Models;
using Portfolio.Models.ViewModels;

namespace PortfolioWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public Project Project { get; set; }
        // public ProjectUpsertVM  UpsertVM { get; set; }
        private readonly ProjectUpsertVM UpsertVM = new();
        public IActionResult Index()
        {
            List<Project> projects = _unitOfWork.Project.GetAll(includeProperties: "Videos").OrderBy(p => p.Order).ToList();
            return View(projects);
        }

        public IActionResult Upsert(int? id)
        {
            // Project = new Project();
           
            // ProjectUpsertVM UpsertVM = new ProjectUpsertVM(Logo = new Logo());
            UpsertVM.Project = new Project();
            
            if (id != null && id != 0)
            {
                UpsertVM.Id = id;
                UpsertVM.Project = _unitOfWork.Project.Get(p => p.Id == id, includeProperties: "Videos");
                UpsertVM.Logos = _unitOfWork.Logo.GetAll().ToList();
                UpsertVM.ProjectLogos = _unitOfWork.ProjectLogo.GetAll(l => l.ProjectId == id).ToList(); // .Where(l => l.ProjectId == id).ToList();
            }

            if (UpsertVM.Project.Videos == null)
            {
                UpsertVM.Project.Videos = [];
            }
            
            return View(UpsertVM);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Project> projectList = _unitOfWork.Project.GetAll(includeProperties: "Videos").OrderBy(p => p.Order).ToList();
            return Json(new { data = projectList });
        }


        [HttpPost]
        public IActionResult Upsert(Project updatedProject, List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedProject);
            }
            if (files != null && files.Count != 0)
            {
                IFormFile file = files[0];
                string oldFileName = updatedProject.Image;
                updatedProject.Image = Guid.NewGuid().ToString() + "-" + file.FileName;

                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, @"img\projects\");
                string newImagePath = Path.Combine(imageDirectory, updatedProject.Image);
                string oldImagePath = Path.Combine(imageDirectory, oldFileName);

                if (!Directory.Exists(imageDirectory))
                {
                    Directory.CreateDirectory(imageDirectory);
                }
                    
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete (oldImagePath);
                }

                using var fileStream = new FileStream(newImagePath, FileMode.Create);
                file.CopyTo(fileStream);
            }


            List<Video> videos = updatedProject.Videos;


            if (videos != null)
            {
                foreach (var video in videos)
                {
                    if (video.Id == 0)
                    {
                        _unitOfWork.Video.Add(video);
                    }
                    else
                    {
                        _unitOfWork.Video.Update(video);
                    }
                }
            }
            

            if (updatedProject.Id == 0)
            {
                _unitOfWork.Project.Add(updatedProject);
                TempData["success"] = "Project created successfully";
            }
            else
            {
                _unitOfWork.Project.Update(updatedProject);
                TempData["success"] = "Project updated successfully";
            }
            _unitOfWork.Save();

            return RedirectToAction("Index");
       
        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var projectToRemove = _unitOfWork.Project.Get(p => p.Id == id);

            if (projectToRemove == null)
            {
                return NotFound();
            }

            string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, @"img\projects\");
            string imagePath = Path.Combine(imageDirectory, projectToRemove.Image);


            if (Directory.Exists(imageDirectory) && System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _unitOfWork.Project.Remove(projectToRemove);
            _unitOfWork.Save();

            TempData["success"] = "Project deleted successfully";

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult DeleteVideo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoToRemove = _unitOfWork.Video.Get(v => v.Id == id);
            if (videoToRemove == null)
            {
                return Json(new { success = true, message = $"Unable to delete video with id {id}" });
            }

            _unitOfWork.Video.Remove(videoToRemove);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Video successfully deleted" });
        }
    }
}
