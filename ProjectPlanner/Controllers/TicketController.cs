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

        public IActionResult Edit(int ticketId)
        {

            TicketBoardVM ticketBoard = new TicketBoardVM();
            ticketBoard.Ticket = _db.Tickets.FirstOrDefault(u => u.Id == ticketId);
            ticketBoard.Project = _db.Projects.FirstOrDefault(u => u.Id == ticketBoard.Ticket.ProjectId);

            return View(ticketBoard);

        }

        [HttpPost]
        public IActionResult Edit(Ticket ticket)
        {
            _db.Tickets.Update(ticket);
            _db.SaveChanges();

            return RedirectToAction("Details", "Project", new { id = ticket.ProjectId });
        }
        public IActionResult Delete(int ticketId)
        {

            TicketBoardVM ticketBoard = new TicketBoardVM();
            ticketBoard.Ticket = _db.Tickets.FirstOrDefault(u => u.Id == ticketId);
            ticketBoard.Project = _db.Projects.FirstOrDefault(u => u.Id == ticketBoard.Ticket.ProjectId);
    
            return View(ticketBoard);

        }

        [HttpPost]
        public IActionResult Delete(TicketBoardVM ticketBoard)
        {

            _db.Tickets.Remove(ticketBoard.Ticket);
            _db.SaveChanges();

            return RedirectToAction("Details", "Project", new { id = ticketBoard.Ticket.ProjectId });
        }
       
    }
}
