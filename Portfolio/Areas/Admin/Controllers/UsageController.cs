using Microsoft.AspNetCore.Mvc;
using Portfolio.DataAccess.Repository.IRepository;
using Portfolio.DataAccess.Repository;
using Portfolio.Models;
using Portfolio.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace PortfolioWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsageController(IUnitOfWork unitOfWork) : Controller
    {

        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        UsageVM UsageVM { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var GENERAL_NAV = "Nav Link";
            var PORTFOLIO_PAGE = "Portfolio Page";

            var usages = new List<Usage>();
            var projIdDict = new Dictionary<int, string>();
            var urlDict = new Dictionary<string, (string, string, string)>(); // <URL, (Type, Label, Project)>

            var videos = _unitOfWork.Video.GetAll();
            var projects = _unitOfWork.Project.GetAll();
            var guestActions = _unitOfWork.GuestAction.GetAll();


            foreach (var project in projects)
            {
                if (project.GitUrl != null)
                {
                    urlDict.TryAdd(project.GitUrl, ("GitHub Page", "GithHub", project.Title));
                }
                if (project.DemoUrl != null)
                {
                    urlDict.TryAdd(project.DemoUrl, ("Demo Link", "Demo", project.Title));
                }

                projIdDict.TryAdd(project.Id, project.Title);
            }

            foreach (var video in videos)
            {
                urlDict.TryAdd(video.URL, ("Video", video.Title, projIdDict[video.ProjectId]));
            }

            foreach (var guestAction in guestActions)
            {
                if (guestAction == null) continue;

                var usage = new Usage
                {
                    Guest = guestAction.UserId,
                    Type = GENERAL_NAV,
                    Project = PORTFOLIO_PAGE,
                    DateTime = guestAction.DateTime,
                    Date = guestAction.DateTime.Date.ToLocalTime().ToString("d"),
                    Time = guestAction.DateTime.ToLocalTime().ToLongTimeString()
                };

                if (guestAction.Url.Equals("https://github.com/nitnub"))
                {
                    usage.Label = "GitHub Profile";
                }

                else if (guestAction.Url.Contains("https://linkedin.com"))
                {
                    usage.Label = "LinkedIn Profile";
                }

                else if (urlDict.TryGetValue(guestAction.Url, out (string, string, string) tup))
                {
                    usage.Type = tup.Item1;
                    usage.Label = tup.Item2;
                    usage.Project = tup.Item3;
                }

                usages.Add(usage);
            }

            return Json(new { data = usages });
        }
    }
}
