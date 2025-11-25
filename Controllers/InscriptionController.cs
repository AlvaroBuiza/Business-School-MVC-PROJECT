using Business_School_VF.Data;
using Business_School_VF.Models;
using Business_School_VF.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Business_School_VF.Controllers
{
    [Authorize(Roles = "Admin,Student")]
    public class InscriptionController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public ApplicationDbContext _db;
       

        public InscriptionController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllStudents()
        {
            var students = await _db.Students.ToListAsync();
            return View(students);
        }




        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            if (!ModelState.IsValid) return View(student);

            _db.Students.Update(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllStudents");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _db.Students.FindAsync(id);
                if (student == null)
                    return Json(new { success = false, message = "Student not found" });

                if (!string.IsNullOrEmpty(student.StudentUser))
                {
                    var user = await _userManager.FindByEmailAsync(student.StudentUser);
                    if (user != null)
                    {
                        var result = await _userManager.DeleteAsync(user);
                        if (!result.Succeeded)
                            return Json(new { success = false, message = "Error deleting Identity user" });
                    }
                }

                _db.Students.Remove(student);
                await _db.SaveChangesAsync();

                return Json(new { success = true, id = id });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Unexpected error: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateInscription()
        {
            var userName = User.Identity?.Name;
            var student = await _db.Students.FirstOrDefaultAsync(s => s.StudentUser == userName);
            if (student == null) return NotFound("Student not found");

            var clubs = await _db.Clubs
                .Select(c => new { c.ClubId, c.ClubName })
                .ToListAsync();

            var vm = new CreateInscriptionViewModel
            {
                StudentId = student.StudentId,
                StudentUser = student.StudentUser,
                Clubs = new SelectList(clubs, "ClubId", "ClubName")
            };

            return View(vm);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateInscription(CreateInscriptionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Clubs = new SelectList(await _db.Clubs.ToListAsync(), "ClubId", "ClubName");
                return View(vm);
            }

            
            bool alreadyExists = await _db.Inscriptions
                .AnyAsync(i => i.StudentId == vm.StudentId && i.ClubId == vm.ClubId);

            if (alreadyExists)
            {
                ModelState.AddModelError("", "You are already registered in this club.");
                vm.Clubs = new SelectList(await _db.Clubs.ToListAsync(), "ClubId", "ClubName");
                return View(vm);
            }

            var inscription = new Inscription
            {
                StudentId = vm.StudentId,
                ClubId = (int)vm.ClubId
            };

            _db.Inscriptions.Add(inscription);
            await _db.SaveChangesAsync();

            return RedirectToAction("MyInscriptions");
        }

        
        public async Task<IActionResult> MyInscriptions()
        {
            var userName = User.Identity?.Name;
            var student = await _db.Students.FirstOrDefaultAsync(s => s.StudentUser == userName);
            if (student == null) return NotFound("Student not found");

            var inscriptions = await _db.Inscriptions
                .Include(i => i.Club)
                .Where(i => i.StudentId == student.StudentId)
                .ToListAsync();

            return View(inscriptions);
        }

        
        [HttpPost]
        public async Task<IActionResult> DeleteInscription(int id)
        {
            var inscription = await _db.Inscriptions.FindAsync(id);
            if (inscription == null) return Json(new { success = false });

            _db.Inscriptions.Remove(inscription);
            await _db.SaveChangesAsync();

            return Json(new { success = true });
        }


    }
}
