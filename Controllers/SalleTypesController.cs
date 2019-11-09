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
    public class SalleTypesController : Controller
    {
        private readonly EtudiantContext _context;

        public SalleTypesController(EtudiantContext context)
        {
            _context = context;
        }

        // GET: SalleTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Type.ToListAsync());
        }

        // GET: SalleTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salleType = await _context.Type
                .FirstOrDefaultAsync(m => m.SalleTypeId == id);
            if (salleType == null)
            {
                return NotFound();
            }

            return View(salleType);
        }

        // GET: SalleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalleTypeId,name")] SalleType salleType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salleType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salleType);
        }

        // GET: SalleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salleType = await _context.Type.FindAsync(id);
            if (salleType == null)
            {
                return NotFound();
            }
            return View(salleType);
        }

        // POST: SalleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalleTypeId,name")] SalleType salleType)
        {
            if (id != salleType.SalleTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salleType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalleTypeExists(salleType.SalleTypeId))
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
            return View(salleType);
        }

        // GET: SalleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salleType = await _context.Type
                .FirstOrDefaultAsync(m => m.SalleTypeId == id);
            if (salleType == null)
            {
                return NotFound();
            }

            return View(salleType);
        }

        // POST: SalleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salleType = await _context.Type.FindAsync(id);
            _context.Type.Remove(salleType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalleTypeExists(int id)
        {
            return _context.Type.Any(e => e.SalleTypeId == id);
        }
    }
}
