using Business_School_VF.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business_School_VF.ViewModel
{
    public class ClubCreateClubViewModel
    {

        public Club? Club { get; set; }
        public int DepartmentId { get; set; }
        public SelectList? DepartamentList { get; set; }

    }
}
