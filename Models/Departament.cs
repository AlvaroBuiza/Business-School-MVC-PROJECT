using System.ComponentModel.DataAnnotations;

namespace Business_School_VF.Models
{
    public class Departament
    {
        public int DepartamentId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 50 characters")]
        public string? DepartamentName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Phone number must contain exactly 9 digits")]
        public string? Phone_Number { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Must be a valid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Office location is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Office location must be between 6 and 50 characters")]
        public string? Office_Location { get; set; }
    }
}
