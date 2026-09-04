using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.Repository;
using Portfolio.DataAccess.Repository.IRepository;
using Portfolio.Models;

namespace PortfolioWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LogosController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public Logo Logo { get; set; }
        public IActionResult Index()
        {
            List<Logo> logos = _unitOfWork.Logo.GetAll().OrderBy(l => l.Name).ToList();
            return View(logos);
        }

        public IActionResult Upsert(int? id)
        {
            Logo = new Logo();

            if (id != null && id != 0)
            {
                // Logo = _unitOfWork.Logo.Get(l => l.Id == id, includeProperties: "Videos");
                Logo = _unitOfWork.Logo.Get(l => l.Id == id);
            }

            // if (Project.Videos == null)
            // {
            //     Project.Videos = [];
            // }

            return View(Logo);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Logo> logoList = _unitOfWork.Logo.GetAll().OrderBy(l => l.Name).ToList();
            return Json(new { data = logoList });
        }
        
        [HttpGet]
        public IActionResult Get(int id)
        {
            Logo logo = _unitOfWork.Logo.Get(l => l.Id == id);
            return Json(new { success = true, logo });
        }


        [HttpPost]
        public IActionResult Upsert(Logo updatedLogo, List<IFormFile> files)
        {
            if (updatedLogo.Id == 0)
            {
                _unitOfWork.Logo.Add(updatedLogo);
                TempData["success"] = "Logo created successfully";
            }
            else
            {
                _unitOfWork.Logo.Update(updatedLogo);
                TempData["success"] = "Logo updated successfully";
            }
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int? id)
        {
            Console.WriteLine("In Delete...");
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var logoToRemove = _unitOfWork.Logo.Get(l => l.Id == id);

            if (logoToRemove == null)
            {
                return NotFound();
            }



            _unitOfWork.Logo.Remove(logoToRemove);
            _unitOfWork.Save();

            TempData["success"] = "Logo deleted successfully";

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult DeleteLogo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            var logoToRemove = _unitOfWork.Logo.Get(l => l.Id == id);
            if (logoToRemove == null)
            {
                return Json(new { success = true, message = $"Unable to delete logo with id {id}" });
            }
        
            _unitOfWork.Logo.Remove(logoToRemove);
            _unitOfWork.Save();
        
            return Json(new { success = true, message = "Logo successfully deleted" });
        }
    }
}
