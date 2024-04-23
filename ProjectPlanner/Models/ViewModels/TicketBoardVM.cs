using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectPlanner.Utilities;

namespace ProjectPlanner.Models.ViewModels
{
    public class TicketBoardVM
    {
        public Ticket Ticket { get; set; }
        public Project Project { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public IEnumerable<SelectListItem> PriorityList { get; set; }

        public TicketBoardVM()
        {

            List<string> priorityList = new List<string>();
            priorityList.Add(SD.priority_low);
            priorityList.Add(SD.priority_medium);
            priorityList.Add(SD.priority_high);


            PriorityList = priorityList.ToList().Select(u => new SelectListItem
            {
                Text = u,
                Value = u
            });

            List<string> statusList = new List<string>();
            statusList.Add(SD.status_new);
            statusList.Add(SD.status_progress);
            statusList.Add(SD.status_waiting);
            statusList.Add(SD.status_done);

            StatusList = statusList.ToList().Select(u => new SelectListItem
            {
                Text = u,
                Value = u
            });


        }
    }
}
