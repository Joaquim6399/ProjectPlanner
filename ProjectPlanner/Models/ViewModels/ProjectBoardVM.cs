namespace ProjectPlanner.Models.ViewModels
{
    public class ProjectBoardVM
    {
        public Project Project { get; set; }
        public IEnumerable<Ticket> ListOfTickets { get; set; }

    }
}
