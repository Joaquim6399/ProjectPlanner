using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPlanner.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60,MinimumLength =3)]
        public string Name { get; set; }
        public string? Description { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public IdentityUser User { get; set; }
        [ValidateNever]
        public string UserId { get; set; }

    }
}
