namespace Business_School_VF.Models
{
    public class Club
    {

        public int ClubId { get; set; }
        public string? ClubName { get; set; }


        public int DepartamentId { get; set; }
        public Departament? Departament { get; set; }
    }
}
