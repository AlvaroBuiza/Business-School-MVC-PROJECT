using System.ComponentModel.DataAnnotations;

namespace Business_School_VF.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Email/username is required")]
        [EmailAddress(ErrorMessage = "Must be a valid email format")]
        public string? PersonUser { get; set; }
    }
}
