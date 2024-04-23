using Microsoft.AspNetCore.Mvc;
using ProjectPlanner.Data;
using ProjectPlanner.Models;

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

        public IActionResult Edit(int id)
        {
            Project projectFromDb = _db.Projects.FirstOrDefault(u => u.Id == id);

            return View(projectFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Project project)
        {

            if(project != null)
            {
                _db.Projects.Update(project);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            if(project != null)
            {
                _db.Projects.Add(project);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Project projectFromDb = _db.Projects.FirstOrDefault(u => u.Id == id);

            return View(projectFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Project project)
        {

            if(project != null)
            {
                _db.Projects.Remove(project);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
