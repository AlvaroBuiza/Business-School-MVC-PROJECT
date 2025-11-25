using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business_School_VF.ViewModel
{
    public class CreateInscriptionViewModel
    {
        public int StudentId { get; set; }
        public string? StudentUser { get; set; }

        [Required(ErrorMessage = "Club selection is required")]
        public int? ClubId { get; set; } 

        public SelectList? Clubs { get; set; }
    }
}
