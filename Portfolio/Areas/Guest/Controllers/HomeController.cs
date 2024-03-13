using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Portfolio.DataAccess.Repository.IRepository;
using Portfolio.Models;
using Portfolio.Models.ViewModels;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace PortfolioWeb.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly HomeVM homeVM = new();

        public IActionResult Index(string projectTest, string idTest)
        {
            HttpContext.Session.Set("VisitorType", Encoding.UTF8.GetBytes("Guest"));

            var activeBiography = _unitOfWork.Biography.GetAll().FirstOrDefault();
            var activeProjects = _unitOfWork.Project.GetAll(p => p.Active && !string.IsNullOrEmpty(p.Image), includeProperties: "Videos,ProjectLogos,ProjectLogos.Logo")
                                                    .OrderBy(p => p.Order)
                                                    .ToList();     

            foreach(var project in activeProjects) 
            {
                if (project.ProjectLogos == null) continue;
                project.ProjectLogos.Sort((l1, l2) => l1.Priority - l2.Priority);
            }

            homeVM.Biography = activeBiography;
            homeVM.Projects = activeProjects;

            return View(homeVM);
        }

        [HttpPost]
        public IActionResult? GuestAction([FromBody] GuestAction guestAction)
        {
            if (guestAction?.Url != null && !User.Identity.IsAuthenticated)
            {
                guestAction.DateTime = DateTime.Now;
                guestAction.UserId = HttpContext.Session.Id[24..];

                _unitOfWork.GuestAction.Add(guestAction);
                _unitOfWork.Save();
            }
   
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
