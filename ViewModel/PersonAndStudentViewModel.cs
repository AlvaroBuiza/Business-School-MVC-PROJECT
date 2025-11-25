using Business_School_VF.Models;

namespace Business_School_VF.ViewModel
{
    public class PersonAndStudentViewModel
    {
        public Person DepartmentManager { get; set; } = new();
        public Person ClubLeader { get; set; } = new();
        public Student Student { get; set; } = new();
    }
}
