using Azure.Core;
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
    [Authorize(Roles = "Admin,ClubLeader")]
    public class ClubController : Controller
    {
        

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public ApplicationDbContext _db;

        public ClubController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> AllClubs()
        {
            var clubs = await _db.Clubs.Include(c => c.Departament).ToListAsync();
            return View(clubs);
        }

        public async Task<IActionResult> CreateClub()
        {

            var departments = await _db.Departaments.Select(d => new
            {
                Id = d.DepartamentId,
                Value = d.DepartamentName

            }).ToListAsync();

            ClubCreateClubViewModel vm = new ClubCreateClubViewModel()
            {
                DepartamentList = new SelectList(departments, "Id", "Value")
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClub(ClubCreateClubViewModel vm)
        {


            Club c = new Club() { 
                ClubName = vm!.Club!.ClubName,
                DepartamentId = vm.DepartmentId
            };

            _db.Add(c);
            await _db.SaveChangesAsync();

            return RedirectToAction("AllClubs");  

           
        }

        public async Task<IActionResult> EditClub(int id)
        {
            var club = await _db.Clubs.FindAsync(id);
            if (club == null) return NotFound();

            var departments = await _db.Departaments.Select(d => new
            {
                Id = d.DepartamentId,
                Value = d.DepartamentName

            }).ToListAsync();

            ClubCreateClubViewModel vm = new ClubCreateClubViewModel()
            {
                Club = club,
                DepartamentList = new SelectList(departments, "Id", "Value")
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditClub(ClubCreateClubViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _db.Update(vm.Club);
                await _db.SaveChangesAsync();
                return RedirectToAction("AllClubs");
            }
            
            return RedirectToAction("AllClubs");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var club = await _db.Clubs.FindAsync(id);
            if (club == null)
                return Json(new { success = false, message = "Club no encontrado" });

            _db.Clubs.Remove(club);
            await _db.SaveChangesAsync();
            return Json(new { success = true, id });
        }

    }
}
