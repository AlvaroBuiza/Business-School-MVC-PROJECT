using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business_School_VF.ViewModel
{
    public class ClubCreateClubViewModel
    {
        public int ClubId { get; set; }

        [Required(ErrorMessage = "Club name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The club name must be between 3 and 50 characters")]
        public string? ClubName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int? DepartmentId { get; set; } // Nullable para que Required funcione

        public SelectList? DepartamentList { get; set; }
    }
}
