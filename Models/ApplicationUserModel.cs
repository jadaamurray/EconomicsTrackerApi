using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace EconomicsTrackerApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Personal name fields
        [PersonalData]
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [PersonalData]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        // Computed full name property (not stored in DB)
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        // Adding favourites later
        // public List<Favorite> Favorites { get; set; }
    }
}