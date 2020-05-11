using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KetchupMayoSite.Models;

namespace KetchupMayoSite.Controllers
{
    [Route("ketchup")]
    public class KetchupsController : Controller
    {
        private readonly DBContext _context;

        public KetchupsController(DBContext context)
        {
            _context = context;
        }

        // GET: Ketchups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ketchups.ToListAsync());
        }

        // GET: Ketchups/Details/5
        [Route("/details/{id:int?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketchup = await _context.Ketchups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ketchup == null)
            {
                return NotFound();
            }

            return View(ketchup);
        }

        // GET: Ketchups/Create
        [Route("/create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ketchups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/create")]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,Spiciness,ProductionDate")] Ketchup ketchup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ketchup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ketchup);
        }

        // GET: Ketchups/Edit/5
        [Route("/edit/{id:int?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketchup = await _context.Ketchups.FindAsync(id);
            if (ketchup == null)
            {
                return NotFound();
            }
            return View(ketchup);
        }

        // POST: Ketchups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,Spiciness,ProductionDate")] Ketchup ketchup)
        {
            if (id != ketchup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ketchup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KetchupExists(ketchup.Id))
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
            return View(ketchup);
        }

        // GET: Ketchups/Delete/5
        [Route("/delete/{id:int?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketchup = await _context.Ketchups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ketchup == null)
            {
                return NotFound();
            }

            return View(ketchup);
        }

        // POST: Ketchups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("/delete/{id:int}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ketchup = await _context.Ketchups.FindAsync(id);
            _context.Ketchups.Remove(ketchup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KetchupExists(int id)
        {
            return _context.Ketchups.Any(e => e.Id == id);
        }
    }
}
