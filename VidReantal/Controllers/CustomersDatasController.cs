using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VidReantal.Data;

namespace VidReantal.Controllers
{
    public class CustomersDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomersDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomersData.ToListAsync());
        }

        // GET: CustomersDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customersData = await _context.CustomersData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customersData == null)
            {
                return NotFound();
            }

            return View(customersData);
        }

        // GET: CustomersDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomersDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ContactNumber,Address,Email,AccountStatus")] CustomersData customersData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customersData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customersData);
        }

        // GET: CustomersDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customersData = await _context.CustomersData.FindAsync(id);
            if (customersData == null)
            {
                return NotFound();
            }
            return View(customersData);
        }

        // POST: CustomersDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ContactNumber,Address,Email,AccountStatus")] CustomersData customersData)
        {
            if (id != customersData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customersData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersDataExists(customersData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customersData);
        }

        // GET: CustomersDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customersData = await _context.CustomersData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customersData == null)
            {
                return NotFound();
            }

            return View(customersData);
        }

        // POST: CustomersDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customersData = await _context.CustomersData.FindAsync(id);
            if (customersData != null)
            {
                _context.CustomersData.Remove(customersData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersDataExists(int id)
        {
            return _context.CustomersData.Any(e => e.Id == id);
        }
    }
}
