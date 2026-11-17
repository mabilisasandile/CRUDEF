using CRUDEF.Data;
using CRUDEF.Entities;
using CRUDEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CRUDEF.Controllers
{
    public class StaffMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffMembers.ToListAsync());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Name,StaffNumber,JobTitle,Email,Phone,Address")] StaffViewModel staff)
        {
            if (ModelState.IsValid)
            {
                Staff obj = new Staff();
                obj.Name = staff.Name;
                obj.StaffNumber = staff.StaffNumber;
                obj.JobTitle = staff.JobTitle;
                obj.Email = staff.Email;
                obj.Phone = staff.Phone;
                obj.Address = staff.Address;
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _context.StaffMembers.FindAsync(id);

            if (person == null)
                return NotFound();

            StaffViewModel model = new StaffViewModel();
            model.Id = person.Id;
            model.Name = person.Name;
            model.StaffNumber = person.StaffNumber;
            model.JobTitle = person.JobTitle;
            model.Email = person.Email;
            model.Phone = person.Phone;
            model.Address = person.Address;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StaffNumber,JobTitle,Email,Phone,Address")] StaffViewModel staff)
        {
            if (id != staff.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var obj = new Staff()
                {
                    Id = staff.Id,
                    Name = staff.Name,
                    StaffNumber = staff.StaffNumber,
                    JobTitle = staff.JobTitle,
                    Email = staff.Email,
                    Phone = staff.Phone,
                    Address = staff.Address
                };

                _context.Update(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var staff = await _context.StaffMembers.FindAsync(id);

            if (staff != null)
            {
                _context.StaffMembers.Remove(staff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
