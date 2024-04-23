using Microsoft.AspNetCore.Mvc;

namespace ProjectPlanner.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
