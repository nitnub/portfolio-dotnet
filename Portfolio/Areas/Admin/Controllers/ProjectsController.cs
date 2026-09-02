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

        // public Project Project { get; set; }
        // public ProjectUpsertVM  UpsertVM { get; set; }
        // private readonly ProjectUpsertVM UpsertVM = new();
        static Project Project { get; set; }
        static ProjectUpsertVM UpsertVM = new();
        
        public IActionResult Index()
        {
            Console.WriteLine("in... ");
            Console.WriteLine("\tpublic IActionResult Index()");
            List<Project> projects = _unitOfWork.Project.GetAll(includeProperties: "Videos").OrderBy(p => p.Order).ToList();
            return View(projects);
        }

        public IActionResult Upsert(int? id)
        {
            // Project = new Project();
            Console.WriteLine("in... ");
            Console.WriteLine("\tpublic IActionResult Upsert(int? id)");
            // ProjectUpsertVM UpsertVM = new ProjectUpsertVM(Logo = new Logo());
            // UpsertVM.Project = new Project();
            UpsertVM.Project =  Project;
            
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
        // public IActionResult Upsert(Project updatedProject, List<IFormFile> files)
        // public IActionResult Upsert(ProjectUpsertVM updatedProject, List<IFormFile> files)
        // public IActionResult Upsert(ProjectUpsertVM updatedProject)
        public IActionResult Upsert(ProjectUpsertVM upsertVM, List<IFormFile> files)
        {
            
            Project updatedProject = upsertVM.Project;
            Console.WriteLine("Id: " + updatedProject.Id);
            // Console.WriteLine("GitURL: " + updatedProject.GitUrl);
            Console.WriteLine("Logo Count: " + updatedProject.ProjectLogos?.Count);
            // Console.WriteLine("Logo : " + updatedProject.ProjectLogos.ToList()[0].Logo);
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Id: " + updatedProject.Id);
                // Console.WriteLine("GitURL: " + updatedProject.GitUrl);
                Console.WriteLine("Logo Count: " + updatedProject.ProjectLogos?.Count);
                Console.WriteLine("Logo : " + updatedProject.ProjectLogos.ToList()[0].Logo);
                // Console.WriteLine("Image: " + updatedProject.Image);
                // Console.WriteLine("Active: " + updatedProject.Active);
                // Console.WriteLine("Port: " + updatedProject.Port);
                // Console.WriteLine("Desc: " + updatedProject.Description);
                // Console.WriteLine("Order: " + updatedProject.Order);
                Console.WriteLine(ModelState);
                Console.WriteLine(ModelState.IsValid);
                // for (int i = 0; i < ModelState.Values.ToList().Count; i++)
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(ModelState.Keys.ToList()[i]); 
                    Console.Write(" - ");
                    Console.WriteLine(ModelState.Values.ToList()[i].Errors.Count);
                }
           
                // ProjectUpsertVM testUpsertVM = new();
                // testUpsertVM.Project = updatedProject;
                // Console.WriteLine("12321");
                // UpsertVM.Project = updatedProject;
                // UpsertVM.Logos = _unitOfWork.Logo.GetAll().ToList();
                return View(UpsertVM);
                // return View(updatedProject);
                // UpsertVM.Project = new  Project();
                // UpsertVM.Id = Project.Id;
                // // UpsertVM.Project = _unitOfWork.Project.Get(p => p.Id == id, includeProperties: "Videos");
                // UpsertVM.ProjectLogos = _unitOfWork.ProjectLogo.GetAll(l => l.ProjectId == Project.Id).ToList(); // .Where(l => l.ProjectId ==
                
                // return View(testUpsertVM);
            }
            
            Console.WriteLine(updatedProject.Image);
            Console.WriteLine(updatedProject.Image);
            Console.WriteLine(updatedProject.Image);

            Console.WriteLine(files.Count);
            Console.WriteLine(files.Count);
            Console.WriteLine(files.Count);
            Console.WriteLine(files.Count);
            
            if (files != null && files.Count != 0)
            {
                IFormFile file = files[0];
                string oldFileName = updatedProject.Image;
                updatedProject.Image = Guid.NewGuid().ToString() + "-" + file.FileName;
            
                // string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, @"img\projects\");
                string subDirectory = Path.Combine("img", "projects");
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, subDirectory);
                
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
            
            List<ProjectLogo> logos = upsertVM.ProjectLogos;
            if (logos != null)
            {
                Console.WriteLine("logos != null");
                Console.WriteLine(logos.Count);
                foreach (var projectLogo in upsertVM.ProjectLogos)
                {
                    Console.WriteLine("ID: "+ projectLogo.Id);
                    Console.WriteLine("LogoId: "+ projectLogo.LogoId);
                    Console.WriteLine("ProjectId: "+ projectLogo.ProjectId);
                    Console.WriteLine("Priority: "+ projectLogo.Priority);
                    if (projectLogo.Id == 0)
                    {
                        _unitOfWork.ProjectLogo.Add(projectLogo);
                    }
                    else
                    {
                        _unitOfWork.ProjectLogo.Update(projectLogo);
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
                
                Console.WriteLine("Creating...");
                Console.WriteLine("updatedProject.Id : " + updatedProject.Id);
                if (updatedProject.ProjectLogos != null)
                {
                    
                foreach (var projectLogo in updatedProject.ProjectLogos)
                {
                    Console.WriteLine("Creating 2...");
                    Console.WriteLine("updatedProject.ProjectLogos.Id : " + projectLogo.Id);
                }
                }

                updatedProject.ProjectLogos = upsertVM.ProjectLogos;
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
        
        [HttpDelete]
        public IActionResult DeleteProjectLogo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectLogoToRemove = _unitOfWork.ProjectLogo.Get(l => l.Id == id);
            if (projectLogoToRemove == null)
            {
                return Json(new { success = true, message = $"Unable to delete projectLogo with id {id}" });
            }

            _unitOfWork.ProjectLogo.Remove(projectLogoToRemove);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Project logo successfully deleted" });
        }
    }
}
