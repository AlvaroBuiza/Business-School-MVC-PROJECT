using Business_School_VF.Data;
using Business_School_VF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business_School_VF.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly ApplicationDbContext _db;
        public DepartmentController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> AllDepartments()
        {
            var departments = await _db.Departaments.ToListAsync();
            return View(departments);
        }

        public IActionResult CreateDepartment()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Departament dept)
        {
            if (ModelState.IsValid)
            {
                _db.Departaments.Add(dept);
                await _db.SaveChangesAsync();
                return RedirectToAction("AllDepartments");
            }
            return View();
        }

        
        public async Task<IActionResult> EditDepartment(int id)
        {
            var dept = await _db.Departaments.FindAsync(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> EditDepartment(Departament dept)
        {
            if (ModelState.IsValid)
            {
                _db.Update(dept);
                await _db.SaveChangesAsync();
                return RedirectToAction("AllDepartments");
            }
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var dept = await _db.Departaments.FindAsync(id);
            if (dept != null)
            {
                _db.Departaments.Remove(dept);
                await _db.SaveChangesAsync();
            }

            return Json(new { success = true, id = id });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
