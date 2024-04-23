using Microsoft.AspNetCore.Mvc;
using ProjectPlanner.Data;
using ProjectPlanner.Models.ViewModels;

namespace ProjectPlanner.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TicketController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int projectId)
        {
            TicketBoardVM ticketBoard = new TicketBoardVM();
            ticketBoard.Project = _db.Projects.FirstOrDefault(u => u.Id == projectId);


            return View(ticketBoard);
        }

    }
}
