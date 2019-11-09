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
    public class CoursController : Controller
    {
        private readonly EtudiantContext _context;

        public CoursController(EtudiantContext context)
        {
            _context = context;
        }

        // GET: Cours
        public async Task<IActionResult> Index()
        {
            var etudiantContext = _context.Cours.Include(c => c.Enseignant).Include(c => c.Salle);
            return View(await etudiantContext.ToListAsync());
        }

        // GET: Cours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cour = await _context.Cours
                .Include(c => c.Enseignant)
                .Include(c => c.Salle)
                .FirstOrDefaultAsync(m => m.CourId == id);
            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // GET: Cours/Create
        public IActionResult Create()
        {
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "EnseignantId", "cin");
            ViewData["SalleId"] = new SelectList(_context.Salles, "SalleId", "numero");
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourId,name,EnseignantId,SalleId")] Cour cour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "EnseignantId", "cin", cour.EnseignantId);
            ViewData["SalleId"] = new SelectList(_context.Salles, "SalleId", "SalleId", cour.SalleId);
            return View(cour);
        }

        // GET: Cours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cour = await _context.Cours.FindAsync(id);
            if (cour == null)
            {
                return NotFound();
            }
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "EnseignantId", "cin", cour.EnseignantId);
            ViewData["SalleId"] = new SelectList(_context.Salles, "SalleId", "SalleId", cour.SalleId);
            return View(cour);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourId,name,EnseignantId,SalleId")] Cour cour)
        {
            if (id != cour.CourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourExists(cour.CourId))
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
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "EnseignantId", "cin", cour.EnseignantId);
            ViewData["SalleId"] = new SelectList(_context.Salles, "SalleId", "SalleId", cour.SalleId);
            return View(cour);
        }

        // GET: Cours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cour = await _context.Cours
                .Include(c => c.Enseignant)
                .Include(c => c.Salle)
                .FirstOrDefaultAsync(m => m.CourId == id);
            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cour = await _context.Cours.FindAsync(id);
            _context.Cours.Remove(cour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourExists(int id)
        {
            return _context.Cours.Any(e => e.CourId == id);
        }
    }
}
