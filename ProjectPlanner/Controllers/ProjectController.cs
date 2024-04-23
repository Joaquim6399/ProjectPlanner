using Microsoft.AspNetCore.Mvc;
using ProjectPlanner.Data;

namespace ProjectPlanner.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            var projects = _db.Projects.ToList();

            return View(projects);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
