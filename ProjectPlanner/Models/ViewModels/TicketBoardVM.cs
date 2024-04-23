using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectPlanner.Models.ViewModels
{
    public class TicketBoardVM
    {
        public Ticket Ticket { get; set; }
        public Project Project { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public IEnumerable<SelectListItem> PriorityList { get; set; }

    }
}
