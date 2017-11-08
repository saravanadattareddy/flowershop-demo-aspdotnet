using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerShop.Data;
using FlowerShop.Models;

namespace FlowerShop.Controllers
{
    public class OccasionsController : Controller
    {
        private readonly GeneralContext _context;

        public OccasionsController(GeneralContext context)
        {
            _context = context;    
        }

        // GET: Occasions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Occassions.ToListAsync());
        }

        // GET: Occasions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occasion = await _context.Occassions
                .SingleOrDefaultAsync(m => m.OccasionId == id);
            if (occasion == null)
            {
                return NotFound();
            }

            return View(occasion);
        }

        // GET: Occasions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Occasions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OccasionId,Occasion_Name,Description")] Occasion occasion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(occasion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(occasion);
        }

        // GET: Occasions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occasion = await _context.Occassions.SingleOrDefaultAsync(m => m.OccasionId == id);
            if (occasion == null)
            {
                return NotFound();
            }
            return View(occasion);
        }

        // POST: Occasions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OccasionId,Occasion_Name,Description")] Occasion occasion)
        {
            if (id != occasion.OccasionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(occasion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OccasionExists(occasion.OccasionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(occasion);
        }

        // GET: Occasions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occasion = await _context.Occassions
                .SingleOrDefaultAsync(m => m.OccasionId == id);
            if (occasion == null)
            {
                return NotFound();
            }

            return View(occasion);
        }

        // POST: Occasions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var occasion = await _context.Occassions.SingleOrDefaultAsync(m => m.OccasionId == id);
            _context.Occassions.Remove(occasion);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OccasionExists(int id)
        {
            return _context.Occassions.Any(e => e.OccasionId == id);
        }
    }
}
