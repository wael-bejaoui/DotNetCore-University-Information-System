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
    public class ClassesController : Controller
    {
        private readonly EtudiantContext _context;

        public ClassesController(EtudiantContext context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classes.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes
                .FirstOrDefaultAsync(m => m.ClasseId == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasseId,niveau,nbrEtudiant")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classe);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes.FindAsync(id);
            if (classe == null)
            {
                return NotFound();
            }
            return View(classe);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasseId,niveau,nbrEtudiant")] Classe classe)
        {
            if (id != classe.ClasseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasseExists(classe.ClasseId))
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
            return View(classe);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classe = await _context.Classes
                .FirstOrDefaultAsync(m => m.ClasseId == id);
            if (classe == null)
            {
                return NotFound();
            }

            return View(classe);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classe = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasseExists(int id)
        {
            return _context.Classes.Any(e => e.ClasseId == id);
        }
    }
}
