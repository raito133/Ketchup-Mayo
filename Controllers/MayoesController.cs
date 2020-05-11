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
    [Route("mayo")]
    public class MayoesController : Controller
    {
        private readonly DBContext _context;

        public MayoesController(DBContext context)
        {
            _context = context;
        }

        // GET: Mayoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mayos.ToListAsync());
        }

        // GET: Mayoes/Details/5
        [Route("/details/{id:int?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mayo = await _context.Mayos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mayo == null)
            {
                return NotFound();
            }

            return View(mayo);
        }

        // GET: Mayoes/Create
        [Route("/create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mayoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/create")]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,Mildness,ProductionDate")] Mayo mayo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mayo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mayo);
        }

        // GET: Mayoes/Edit/5
        [Route("/edit/{id:int?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mayo = await _context.Mayos.FindAsync(id);
            if (mayo == null)
            {
                return NotFound();
            }
            return View(mayo);
        }

        // POST: Mayoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,Mildness,ProductionDate")] Mayo mayo)
        {
            if (id != mayo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mayo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MayoExists(mayo.Id))
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
            return View(mayo);
        }

        // GET: Mayoes/Delete/5
        [Route("/delete/{id:int?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mayo = await _context.Mayos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mayo == null)
            {
                return NotFound();
            }

            return View(mayo);
        }

        // POST: Mayoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("/delete/{id:int}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mayo = await _context.Mayos.FindAsync(id);
            _context.Mayos.Remove(mayo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MayoExists(int id)
        {
            return _context.Mayos.Any(e => e.Id == id);
        }
    }
}
