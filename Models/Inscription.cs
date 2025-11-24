namespace Business_School_VF.Models
{
    public class Inscription
    {

        public int InscriptionId { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int ClubId { get; set; }
        public Club? Club { get; set; }
    }
}
