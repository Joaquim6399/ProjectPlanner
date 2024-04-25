using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectPlanner.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60,MinimumLength =3)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public IdentityUser User { get; set; }


    }
}
