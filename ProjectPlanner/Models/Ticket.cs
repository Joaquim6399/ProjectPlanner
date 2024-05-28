using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPlanner.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60,MinimumLength =3)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [ValidateNever]
        public string Status { get; set; }
        [ValidateNever]
        public string Priority { get; set; }
        public DateTime CreatedOn { get; set; }
        [ValidateNever]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        [ValidateNever]
        public Project Project { get; set; }

    }
}
