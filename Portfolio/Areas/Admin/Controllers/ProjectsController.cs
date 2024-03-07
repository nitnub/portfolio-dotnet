using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.Repository;
using Portfolio.DataAccess.Repository.IRepository;
using Portfolio.Models;

namespace PortfolioWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public Project Project { get; set; }
        public IActionResult Index()
        {
            List<Project> projects = _unitOfWork.Project.GetAll(includeProperties: "Videos").OrderBy(p => p.Order).ToList();

            return View(projects);
        }

        public IActionResult Upsert(int? id)
        {
            Project = new Project();

            if (id != null && id != 0)
            {
                Project = _unitOfWork.Project.Get(p => p.Id == id, includeProperties: "Videos");
            }

            if (Project.Videos == null)
            {
                Project.Videos = [];
            }

            return View(Project);
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
            List<Video> videos = updatedProject.Videos;

            if (ModelState.IsValid)
            {
                if (files != null && files.Count != 0)
                {
                    IFormFile file = files[0];
                    string oldFileName = updatedProject.Image;
                    updatedProject.Image = Guid.NewGuid().ToString() + "-" + file.FileName;

                    string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, @"img\projects\");
                    string newImageFile = Path.Combine(imageDirectory, updatedProject.Image);
                    string oldImageFile = Path.Combine(imageDirectory, oldFileName);

                    if (!Directory.Exists(imageDirectory))
                    {
                        Directory.CreateDirectory(imageDirectory);
                    }
                    
                    if (System.IO.File.Exists(oldImageFile))
                    {
                        System.IO.File.Delete (oldImageFile);
                    }

                    using var fileStream = new FileStream(newImageFile, FileMode.Create);
                    file.CopyTo(fileStream);
                }

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
            else
            {
                return View(updatedProject);
            }
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
            string imageFile = Path.Combine(imageDirectory, projectToRemove.Image);


            if (Directory.Exists(imageDirectory) && System.IO.File.Exists(imageFile))
            {
                System.IO.File.Delete(imageFile);
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
                return Json(new { success = false, message = $"Unable to delete video with id {id}" });
            }

            _unitOfWork.Video.Remove(videoToRemove);
            _unitOfWork.Save();

            //int projectId = videoToRemove.ProjectId;

            return Json(new { success = true, message = "Video successfully deleted" });
        }
    }
}
