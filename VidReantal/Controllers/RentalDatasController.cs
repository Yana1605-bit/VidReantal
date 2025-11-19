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
    public class RentalDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalData.ToListAsync());
        }

        // GET: RentalDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalData == null)
            {
                return NotFound();
            }

            return View(rentalData);
        }

        // GET: RentalDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,MovieTitle,RentalDate,DueDate,ReturnDate,RentalFee,LateFee,TotalFees")] RentalData rentalData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalData);
        }

        // GET: RentalDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData.FindAsync(id);
            if (rentalData == null)
            {
                return NotFound();
            }
            return View(rentalData);
        }

        // POST: RentalDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,MovieTitle,RentalDate,DueDate,ReturnDate,RentalFee,LateFee,TotalFees")] RentalData rentalData)
        {
            if (id != rentalData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalDataExists(rentalData.Id))
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
            return View(rentalData);
        }

        // GET: RentalDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalData = await _context.RentalData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalData == null)
            {
                return NotFound();
            }

            return View(rentalData);
        }

        // POST: RentalDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalData = await _context.RentalData.FindAsync(id);
            if (rentalData != null)
            {
                _context.RentalData.Remove(rentalData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalDataExists(int id)
        {
            return _context.RentalData.Any(e => e.Id == id);
        }
    }
}
