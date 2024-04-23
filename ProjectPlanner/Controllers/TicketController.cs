using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectPlanner.Data;
using ProjectPlanner.Models;
using ProjectPlanner.Models.ViewModels;
using ProjectPlanner.Utilities;

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

            List<string> priorityList = new List<string>();
            priorityList.Add(SD.priority_low);
            priorityList.Add(SD.priority_medium);
            priorityList.Add(SD.priority_high);


            ticketBoard.PriorityList = priorityList.ToList().Select( u => new SelectListItem
            {
                Text =  u,
                Value = u
            });
            
            return View(ticketBoard);
        }

        [HttpPost]
        public IActionResult Create(TicketBoardVM ticketBoard)
        {
            Ticket newTicket = ticketBoard.Ticket;
            newTicket.Status = SD.status_new;
            newTicket.CreatedOn = DateTime.Now;
            newTicket.ProjectId = ticketBoard.Project.Id;

           
            
            if (newTicket != null)
            {
                if (newTicket.Priority == null)
                {
                    newTicket.Priority = SD.priority_medium;
                }

                _db.Tickets.Add(newTicket);
                _db.SaveChanges();
            }
            return RedirectToAction("Details", "Project", new { id = ticketBoard.Project.Id });
        }
    }
}
