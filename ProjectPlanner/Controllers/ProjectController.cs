using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectPlanner.Data;
using ProjectPlanner.Models;
using ProjectPlanner.Models.ViewModels;
using ProjectPlanner.Utilities;
using System.Security.Claims;

namespace ProjectPlanner.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var projects = _db.Projects.ToList().Where(u=>u.UserId == userId);
            

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

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            project.UserId = userId;

            if (ModelState.IsValid)
            {

                _db.Projects.Update(project);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            project.UserId = userId;

            if (ModelState.IsValid)
            {
                _db.Projects.Add(project);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(project);
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
        
        public IActionResult Details(int id)
        {
            ProjectBoardVM projectBoard = new ProjectBoardVM();

            projectBoard.Project = _db.Projects.FirstOrDefault(u => u.Id == id);
            projectBoard.ListOfTickets = _db.Tickets.ToList().Where(u => u.ProjectId == projectBoard.Project.Id).OrderBy(u => u.Status, new MyComparer());


            return View(projectBoard);
        }
    }
}
