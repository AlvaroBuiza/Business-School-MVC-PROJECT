using Business_School_VF.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Business_School_VF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Person> Person => Set<Person>();
        public DbSet<Departament> Departaments => Set<Departament>();
        public DbSet<Club> Clubs => Set<Club>();
        public DbSet<Inscription> Inscriptions => Set<Inscription>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           
            builder.Entity<Departament>().HasData(
                new Departament
                {
                    DepartamentId = 1,
                    DepartamentName = "Marketing",
                    Phone_Number = "600123456",
                    Email = "marketing@businesschool.com",
                    Office_Location = "Building A - Room 201"
                },
                new Departament
                {
                    DepartamentId = 2,
                    DepartamentName = "Finance",
                    Phone_Number = "600654321",
                    Email = "finance@businesschool.com",
                    Office_Location = "Building B - Room 105"
                },
                new Departament
                {
                    DepartamentId = 3,
                    DepartamentName = "Management",
                    Phone_Number = "601111222",
                    Email = "management@businesschool.com",
                    Office_Location = "Building C - Room 310"
                }
            );

            
            builder.Entity<Club>().HasData(
                new Club
                {
                    ClubId = 1,
                    ClubName = "Marketing Student Association",
                    DepartamentId = 1
                },
                new Club
                {
                    ClubId = 2,
                    ClubName = "Finance Investment Club",
                    DepartamentId = 2
                },
                new Club
                {
                    ClubId = 3,
                    ClubName = "Leadership & Strategy Club",
                    DepartamentId = 3
                }
            );

            
            builder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    PersonName = "Carlos Ruiz",
                    Birthday = new DateTime(1990, 5, 1),
                    PersonUser = "carlos_ruiz"
                },
                new Person
                {
                    PersonId = 2,
                    PersonName = "Elena Torres",
                    Birthday = new DateTime(1985, 12, 20),
                    PersonUser = "elena_torres"
                }
            );

            
            builder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    StudentName = "Ana García",
                    Birthday = new DateTime(2001, 3, 12),
                    StudentUser = "ana_garcia"
                },
                new Student
                {
                    StudentId = 2,
                    StudentName = "Luis Martínez",
                    Birthday = new DateTime(2000, 8, 23),
                    StudentUser = "luis_martinez"
                },
                new Student
                {
                    StudentId = 3,
                    StudentName = "María López",
                    Birthday = new DateTime(2002, 1, 5),
                    StudentUser = "maria_lopez"
                }
            );

           
            builder.Entity<Inscription>().HasData(
                new Inscription { InscriptionId = 1, StudentId = 1, ClubId = 1 }, // Ana → Marketing Club
                new Inscription { InscriptionId = 2, StudentId = 1, ClubId = 3 }, // Ana → Leadership Club
                new Inscription { InscriptionId = 3, StudentId = 2, ClubId = 2 }, // Luis → Finance Club
                new Inscription { InscriptionId = 4, StudentId = 3, ClubId = 1 }  // Maria → Marketing Club
            );
        }

    }
}
