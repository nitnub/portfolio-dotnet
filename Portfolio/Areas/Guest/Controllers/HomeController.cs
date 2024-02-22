using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Portfolio.DataAccess.Repository.IRepository;
using Portfolio.Models;
using Portfolio.Models.ViewModels;
using System.Diagnostics;

namespace PortfolioWeb.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;
        private HomeVM homeVM;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var activeBiography = _unitOfWork.Biography.GetAll().FirstOrDefault();
            var activeProjects = _unitOfWork.Project.GetAll(p => p.Active && !string.IsNullOrEmpty(p.Image), includeProperties: "Videos,ProjectLogos,ProjectLogos.Logo").OrderBy(p => p.Order).ToList();

            homeVM = new HomeVM()
            {
                Biography = activeBiography,
                Projects = activeProjects,
            };
          
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
