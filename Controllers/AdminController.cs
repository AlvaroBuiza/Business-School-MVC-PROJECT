using Business_School_VF.Data;
using Business_School_VF.Models;
using Business_School_VF.Models.ViewModels;
using Business_School_VF.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    public ApplicationDbContext _db;
    const string passDefault = "Escuela123!";

    public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext db)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _db = db;
    }

    public IActionResult Index() => View();

    
    [HttpPost]
    public async Task<IActionResult> CreateDepartmentManager(PersonAndStudentViewModel vm)
    {
        var p = vm.DepartmentManager;
        ModelState.Clear();

        
        TryValidateModel(p, nameof(vm.DepartmentManager));

        if (!ModelState.IsValid)
        {
           
            return View("Index", vm);
        }

        var user = await _userManager.FindByEmailAsync(p.PersonUser);
        if (user == null)
        {
            var userAregistrar = new IdentityUser
            {
                UserName = p.PersonUser,
                Email = p.PersonUser,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(userAregistrar, passDefault);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userAregistrar, "DepartamentManager");
                _db.Add(p);
                await _db.SaveChangesAsync();
                ViewBag.Message = "Department Manager registered successfully";
            }
            else
            {
                ViewBag.Message = "An error occurred while registering Manager";
            }
        }
        return View("Index");
    }

    
    [HttpPost]
    public async Task<IActionResult> CreateClubLeader(PersonAndStudentViewModel vm)
    {
        var p = vm.ClubLeader;
        ModelState.Clear();


        TryValidateModel(p, nameof(vm.DepartmentManager));

        if (!ModelState.IsValid)
        {

            return View("Index", vm);
        }


        

        var user = await _userManager.FindByEmailAsync(p.PersonUser);
        if (user == null)
        {
            var userAregistrar = new IdentityUser
            {
                UserName = p.PersonUser,
                Email = p.PersonUser,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(userAregistrar, passDefault);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userAregistrar, "ClubLeader");
                _db.Add(p);
                await _db.SaveChangesAsync();
                ViewBag.Message = "Club Leader registered successfully";
            }
            else
            {
                ViewBag.Message = "An error occurred while registering Leader";
            }
        }
        return View("Index");
    }

    
    [HttpPost]
    public async Task<IActionResult> CreateStudent(PersonAndStudentViewModel vm)
    {
        var p = vm.Student;
        ModelState.Clear();


        TryValidateModel(p, nameof(vm.DepartmentManager));

        if (!ModelState.IsValid)
        {

            return View("Index", vm);
        }

        var user = await _userManager.FindByEmailAsync(p.StudentUser);
        if (user == null)
        {
            var userAregistrar = new IdentityUser
            {
                UserName = p.StudentUser,
                Email = p.StudentUser,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(userAregistrar, passDefault);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userAregistrar, "Student");
                _db.Add(p);
                await _db.SaveChangesAsync();
                ViewBag.Message = "Student registered successfully";
            }
            else
            {
                ViewBag.Message = "An error occurred while registering Student";
            }
        }
        return View("Index");
    }

    
    [HttpPost]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var person = await _db.Person.FindAsync(id);
        if (person == null) return Json(new { success = false, message = "Person not found" });

        var user = await _userManager.FindByEmailAsync(person.PersonUser);
        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return Json(new { success = false, message = "Error deleting user" });
            }
        }

        _db.Person.Remove(person);
        await _db.SaveChangesAsync();

        return Json(new { success = true, id });
    }

   
    public async Task<IActionResult> AllPersons()
    {
        var persons = await _db.Person.ToListAsync();
        var vmList = new List<PersonRoleAllPersonViewModel>();

        foreach (var p in persons)
        {
            var user = await _userManager.FindByEmailAsync(p.PersonUser);
            var roles = user != null ? await _userManager.GetRolesAsync(user) : new List<string> { "No role assigned" };

            vmList.Add(new PersonRoleAllPersonViewModel
            {
                person = p,
                rol = roles.FirstOrDefault()
            });
        }
        return View(vmList);
    }

    
    [HttpGet]
    public async Task<IActionResult> EditPerson(int id)
    {
        var person = await _db.Person.FindAsync(id);
        if (person == null) return NotFound();
        return View(person);
    }

    [HttpPost]
    public async Task<IActionResult> EditPerson(Person person)
    {
        if (!ModelState.IsValid) return View(person);

        var existingPerson = await _db.Person.FindAsync(person.PersonId);
        if (existingPerson == null) return NotFound();

        existingPerson.PersonName = person.PersonName;
        existingPerson.Birthday = person.Birthday;
        existingPerson.PersonUser = person.PersonUser;

        _db.Update(existingPerson);
        await _db.SaveChangesAsync();

        TempData["Message"] = "Person updated successfully";
        return RedirectToAction("AllPersons");
    }
}
