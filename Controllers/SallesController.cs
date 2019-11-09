using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_college.Models;

namespace Project_college.Controllers
{
    public class SallesController : Controller
    {
        private readonly EtudiantContext _context;

        public SallesController(EtudiantContext context)
        {
            _context = context;
        }

        // GET: Salles
        public async Task<IActionResult> Index()
        {
            var etudiantContext = _context.Salles.Include(s => s.Type);
            return View(await etudiantContext.ToListAsync());
        }

        // GET: Salles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salle = await _context.Salles
                .Include(s => s.Type)
                .FirstOrDefaultAsync(m => m.SalleId == id);
            if (salle == null)
            {
                return NotFound();
            }

            return View(salle);
        }

        // GET: Salles/Create
        public IActionResult Create()
        {
            ViewData["SalleTypeId"] = new SelectList(_context.Type, "SalleTypeId", "name");
            return View();
        }

        // POST: Salles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalleId,SalleTypeId,numero,nbrPlace")] Salle salle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalleTypeId"] = new SelectList(_context.Type, "SalleTypeId", "SalleTypeId", salle.SalleTypeId);
            return View(salle);
        }

        // GET: Salles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salle = await _context.Salles.FindAsync(id);
            if (salle == null)
            {
                return NotFound();
            }
            ViewData["SalleTypeId"] = new SelectList(_context.Type, "SalleTypeId", "SalleTypeId", salle.SalleTypeId);
            return View(salle);
        }

        // POST: Salles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalleId,SalleTypeId,numero,nbrPlace")] Salle salle)
        {
            if (id != salle.SalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalleExists(salle.SalleId))
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
            ViewData["SalleTypeId"] = new SelectList(_context.Type, "SalleTypeId", "SalleTypeId", salle.SalleTypeId);
            return View(salle);
        }

        // GET: Salles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salle = await _context.Salles
                .Include(s => s.Type)
                .FirstOrDefaultAsync(m => m.SalleId == id);
            if (salle == null)
            {
                return NotFound();
            }

            return View(salle);
        }

        // POST: Salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salle = await _context.Salles.FindAsync(id);
            _context.Salles.Remove(salle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalleExists(int id)
        {
            return _context.Salles.Any(e => e.SalleId == id);
        }
    }
}
