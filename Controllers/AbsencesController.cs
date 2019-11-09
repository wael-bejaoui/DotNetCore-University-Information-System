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
    public class AbsencesController : Controller
    {
        private readonly EtudiantContext _context;

        public AbsencesController(EtudiantContext context)
        {
            _context = context;
        }

        // GET: Absences
        public async Task<IActionResult> Index()
        {
            var etudiantContext = _context.Absences.Include(a => a.Cour).Include(a => a.Etudiant);
            return View(await etudiantContext.ToListAsync());
        }


       

        // GET: Absences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _context.Absences
                .Include(a => a.Cour)
                .Include(a => a.Etudiant)
                .FirstOrDefaultAsync(m => m.AbsenceId == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // GET: Absences/Create
        public IActionResult Create()
        {
            ViewData["CourId"] = new SelectList(_context.Cours, "CourId", "name");
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "EtudiantId", "cin");
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AbsenceId,Date,EtudiantId,CourId")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourId"] = new SelectList(_context.Cours, "CourId", "name", absence.CourId);
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "EtudiantId", "cin", absence.EtudiantId);
            return View(absence);
        }

        // GET: Absences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _context.Absences.FindAsync(id);
            if (absence == null)
            {
                return NotFound();
            }
            ViewData["CourId"] = new SelectList(_context.Cours, "CourId", "name", absence.CourId);
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "EtudiantId", "cin", absence.EtudiantId);
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AbsenceId,Date,EtudiantId,CourId")] Absence absence)
        {
            if (id != absence.AbsenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsenceExists(absence.AbsenceId))
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
            ViewData["CourId"] = new SelectList(_context.Cours, "CourId", "name", absence.CourId);
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "EtudiantId", "cin", absence.EtudiantId);
            return View(absence);
        }

        // GET: Absences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absence = await _context.Absences
                .Include(a => a.Cour)
                .Include(a => a.Etudiant)
                .FirstOrDefaultAsync(m => m.AbsenceId == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var absence = await _context.Absences.FindAsync(id);
            _context.Absences.Remove(absence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceExists(int id)
        {
            return _context.Absences.Any(e => e.AbsenceId == id);
        }
    }
}
