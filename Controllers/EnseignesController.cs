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
    public class EnseignesController : Controller
    {
        private readonly EtudiantContext _context;

        public EnseignesController(EtudiantContext context)
        {
            _context = context;
        }

        // GET: Enseignes
        public async Task<IActionResult> Index()
        {
            var etudiantContext = _context.Enseignes.Include(e => e.Classe).Include(e => e.Enseignant);
            return View(await etudiantContext.ToListAsync());
        }

        // GET: Enseignes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseigne = await _context.Enseignes
                .Include(e => e.Classe)
                .Include(e => e.Enseignant)
                .FirstOrDefaultAsync(m => m.EnseigneId == id);
            if (enseigne == null)
            {
                return NotFound();
            }

            return View(enseigne);
        }

        // GET: Enseignes/Create
        public IActionResult Create()
        {
            ViewData["ClasseId"] = new SelectList(_context.Classes, "ClasseId", "ClasseId");
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "EnseignantId", "cin");
            return View();
        }

        // POST: Enseignes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnseigneId,ClasseId,EnseignantId")] Enseigne enseigne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enseigne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClasseId"] = new SelectList(_context.Classes, "ClasseId", "ClasseId", enseigne.ClasseId);
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "EnseignantId", "cin", enseigne.EnseignantId);
            return View(enseigne);
        }

        // GET: Enseignes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseigne = await _context.Enseignes.FindAsync(id);
            if (enseigne == null)
            {
                return NotFound();
            }
            ViewData["ClasseId"] = new SelectList(_context.Classes, "ClasseId", "ClasseId", enseigne.ClasseId);
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "EnseignantId", "cin", enseigne.EnseignantId);
            return View(enseigne);
        }

        // POST: Enseignes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnseigneId,ClasseId,EnseignantId")] Enseigne enseigne)
        {
            if (id != enseigne.EnseigneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enseigne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseigneExists(enseigne.EnseigneId))
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
            ViewData["ClasseId"] = new SelectList(_context.Classes, "ClasseId", "ClasseId", enseigne.ClasseId);
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "EnseignantId", "cin", enseigne.EnseignantId);
            return View(enseigne);
        }

        // GET: Enseignes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseigne = await _context.Enseignes
                .Include(e => e.Classe)
                .Include(e => e.Enseignant)
                .FirstOrDefaultAsync(m => m.EnseigneId == id);
            if (enseigne == null)
            {
                return NotFound();
            }

            return View(enseigne);
        }

        // POST: Enseignes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enseigne = await _context.Enseignes.FindAsync(id);
            _context.Enseignes.Remove(enseigne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseigneExists(int id)
        {
            return _context.Enseignes.Any(e => e.EnseigneId == id);
        }
    }
}
