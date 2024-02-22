using Microsoft.AspNetCore.Mvc;

namespace PortfolioWeb.Areas.Guest.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
