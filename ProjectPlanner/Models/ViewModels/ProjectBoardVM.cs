namespace ProjectPlanner.Models.ViewModels
{
    public class ProjectBoard
    {
        public Project Project { get; set; }
        public IEnumerable<Ticket> ListOfTickets { get; set; }

    }
}
