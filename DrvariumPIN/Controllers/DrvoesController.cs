using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrvariumPIN.Models;
using Microsoft.AspNetCore.Authorization;

namespace DrvariumPIN.Controllers
{
    public class DrvoesController : Controller
    {
        private readonly DrvosContext _context;

        public DrvoesController(DrvosContext context)
        {
            _context = context;
        }

        // GET: Drvoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drvo.ToListAsync());
        }

        // GET: Drvoes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drvo = await _context.Drvo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drvo == null)
            {
                return NotFound();
            }

            return View(drvo);
        }

        // GET: Drvoes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drvoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vrsta,Opis,SlikaUrl")] Drvo drvo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drvo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drvo);
        }

        // GET: Drvoes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drvo = await _context.Drvo.FindAsync(id);
            if (drvo == null)
            {
                return NotFound();
            }
            return View(drvo);
        }

        // POST: Drvoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vrsta,Opis,SlikaUrl")] Drvo drvo)
        {
            if (id != drvo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drvo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrvoExists(drvo.Id))
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
            return View(drvo);
        }

        // GET: Drvoes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drvo = await _context.Drvo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drvo == null)
            {
                return NotFound();
            }

            return View(drvo);
        }

        // POST: Drvoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drvo = await _context.Drvo.FindAsync(id);
            _context.Drvo.Remove(drvo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrvoExists(int id)
        {
            return _context.Drvo.Any(e => e.Id == id);
        }
    }
}
