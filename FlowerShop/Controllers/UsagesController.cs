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
    public class UsagesController : Controller
    {
        private readonly GeneralContext _context;

        public UsagesController(GeneralContext context)
        {
            _context = context;    
        }

        // GET: Usages
        public async Task<IActionResult> Index()
        {
            var generalContext = _context.Usages.Include(u => u.Occassion).Include(u => u.Product);
            return View(await generalContext.ToListAsync());
        }

        // GET: Usages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usage = await _context.Usages
                .Include(u => u.Occassion)
                .Include(u => u.Product)
                .SingleOrDefaultAsync(m => m.UsageId == id);
            if (usage == null)
            {
                return NotFound();
            }

            return View(usage);
        }

        // GET: Usages/Create
        public IActionResult Create()
        {
            ViewData["OccasionId"] = new SelectList(_context.Occassions, "OccasionId", "Occasion_Name");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Product_Name");
            return View();
        }

        // POST: Usages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsageId,OccasionId,ProductId")] Usage usage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["OccasionId"] = new SelectList(_context.Occassions, "OccasionId", "Occasion_Name", usage.OccasionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Product_Name", usage.ProductId);
            return View(usage);
        }

        // GET: Usages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usage = await _context.Usages.SingleOrDefaultAsync(m => m.UsageId == id);
            if (usage == null)
            {
                return NotFound();
            }
            ViewData["OccasionId"] = new SelectList(_context.Occassions, "OccasionId", "Occasion_Name", usage.OccasionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Product_Name", usage.ProductId);
            return View(usage);
        }

        // POST: Usages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsageId,OccasionId,ProductId")] Usage usage)
        {
            if (id != usage.UsageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsageExists(usage.UsageId))
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
            ViewData["OccasionId"] = new SelectList(_context.Occassions, "OccasionId", "Occasion_Name", usage.OccasionId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Product_Name", usage.ProductId);
            return View(usage);
        }

        // GET: Usages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usage = await _context.Usages
                .Include(u => u.Occassion)
                .Include(u => u.Product)
                .SingleOrDefaultAsync(m => m.UsageId == id);
            if (usage == null)
            {
                return NotFound();
            }

            return View(usage);
        }

        // POST: Usages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usage = await _context.Usages.SingleOrDefaultAsync(m => m.UsageId == id);
            _context.Usages.Remove(usage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UsageExists(int id)
        {
            return _context.Usages.Any(e => e.UsageId == id);
        }
    }
}
