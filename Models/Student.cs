using System.ComponentModel.DataAnnotations;

namespace Business_School_VF.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Email/username is required")]
        [EmailAddress(ErrorMessage = "Must be a valid email format")]
        public string? StudentUser { get; set; }
    }
}
