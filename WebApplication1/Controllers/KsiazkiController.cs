using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class KsiazkiController : Controller
    {
        private readonly KsiazkiContext _context;

        public KsiazkiController(KsiazkiContext context)
        {
            _context = context;
        }

        // GET: Ksiazki
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return _context.Ksiazki != null ?
                        View(await _context.Ksiazki.ToListAsync()) :
                        Problem("Entity set 'KsiazkiContext.Ksiazki'  is null.");
        }

        // GET: Ksiazki/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ksiazki == null)
            {
                return NotFound();
            }

            var ksiazki = await _context.Ksiazki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ksiazki == null)
            {
                return NotFound();
            }

            return View(ksiazki);
        }

        // GET: Ksiazki/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ksiazki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImgURL,Tytul,Ocena")] Ksiazki ksiazki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ksiazki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ksiazki);
        }

        // GET: Ksiazki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ksiazki == null)
            {
                return NotFound();
            }

            var ksiazki = await _context.Ksiazki.FindAsync(id);
            if (ksiazki == null)
            {
                return NotFound();
            }
            return View(ksiazki);
        }

        // POST: Ksiazki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImgURL,Tytul,Ocena")] Ksiazki ksiazki)
        {
            if (id != ksiazki.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ksiazki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KsiazkiExists(ksiazki.Id))
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
            return View(ksiazki);
        }

        // GET: Ksiazki/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ksiazki == null)
            {
                return NotFound();
            }

            var ksiazki = await _context.Ksiazki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ksiazki == null)
            {
                return NotFound();
            }

            return View(ksiazki);
        }

        // POST: Ksiazki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ksiazki == null)
            {
                return Problem("Entity set 'KsiazkiContext.Ksiazki'  is null.");
            }
            var ksiazki = await _context.Ksiazki.FindAsync(id);
            if (ksiazki != null)
            {
                _context.Ksiazki.Remove(ksiazki);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KsiazkiExists(int id)
        {
            return (_context.Ksiazki?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}