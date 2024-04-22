using Microsoft.AspNetCore.Mvc;

namespace ProjectPlanner.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
