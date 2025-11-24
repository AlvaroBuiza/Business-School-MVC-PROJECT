using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business_School_VF.ViewModel
{
    public class CreateInscriptionViewModel
    {

        public int StudentId { get; set; }
        public string? StudentUser { get; set; }

        public int ClubId { get; set; }
        public SelectList? Clubs { get; set; }

    }
}
