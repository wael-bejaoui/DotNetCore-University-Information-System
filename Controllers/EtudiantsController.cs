﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_college.Models;

namespace Project_college.Controllers
{
    public class EtudiantsController : Controller
    {
        private readonly EtudiantContext _context;

        public EtudiantsController(EtudiantContext context)
        {
            _context = context;
        }

        // GET: Etudiants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etudiants.ToListAsync());
        }

        // GET: Etudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants
                .FirstOrDefaultAsync(m => m.EtudiantId == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // GET: Etudiants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtudiantId,Nom,Prenom,cin")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtudiantId,Nom,Prenom,cin")] Etudiant etudiant)
        {
            if (id != etudiant.EtudiantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.EtudiantId))
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
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants
                .FirstOrDefaultAsync(m => m.EtudiantId == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etudiant = await _context.Etudiants.FindAsync(id);
            _context.Etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(int id)
        {
            return _context.Etudiants.Any(e => e.EtudiantId == id);
        }
    }
}
