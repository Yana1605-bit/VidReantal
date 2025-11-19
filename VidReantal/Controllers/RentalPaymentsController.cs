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
    public class RentalPaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalPaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalPayments
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalPayment.ToListAsync());
        }

        // GET: RentalPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPayment = await _context.RentalPayment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalPayment == null)
            {
                return NotFound();
            }

            return View(rentalPayment);
        }

        // GET: RentalPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Total_Rental_Fee,Downpayment,Balance,Mode_of_Payment,Payment_Date")] RentalPayment rentalPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalPayment);
        }

        // GET: RentalPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPayment = await _context.RentalPayment.FindAsync(id);
            if (rentalPayment == null)
            {
                return NotFound();
            }
            return View(rentalPayment);
        }

        // POST: RentalPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Total_Rental_Fee,Downpayment,Balance,Mode_of_Payment,Payment_Date")] RentalPayment rentalPayment)
        {
            if (id != rentalPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalPaymentExists(rentalPayment.Id))
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
            return View(rentalPayment);
        }

        // GET: RentalPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalPayment = await _context.RentalPayment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalPayment == null)
            {
                return NotFound();
            }

            return View(rentalPayment);
        }

        // POST: RentalPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalPayment = await _context.RentalPayment.FindAsync(id);
            if (rentalPayment != null)
            {
                _context.RentalPayment.Remove(rentalPayment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalPaymentExists(int id)
        {
            return _context.RentalPayment.Any(e => e.Id == id);
        }
    }
}
