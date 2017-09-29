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
    public class OrderLnsController : Controller
    {
        private readonly GeneralContext _context;

        public OrderLnsController(GeneralContext context)
        {
            _context = context;    
        }

        // GET: OrderLns
        public async Task<IActionResult> Index()
        {
            var generalContext = _context.OrderLns.Include(o => o.Order).Include(o => o.Product);
            return View(await generalContext.ToListAsync());
        }

        // GET: OrderLns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLn = await _context.OrderLns
                .Include(o => o.Order)
                .Include(o => o.Product)
                .SingleOrDefaultAsync(m => m.OrderLnId == id);
            if (orderLn == null)
            {
                return NotFound();
            }

            return View(orderLn);
        }

        // GET: OrderLns/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: OrderLns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderLnId,Number,ProductId,OrderId")] OrderLn orderLn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderLn);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderLn.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", orderLn.ProductId);
            return View(orderLn);
        }

        // GET: OrderLns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLn = await _context.OrderLns.SingleOrDefaultAsync(m => m.OrderLnId == id);
            if (orderLn == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderLn.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", orderLn.ProductId);
            return View(orderLn);
        }

        // POST: OrderLns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderLnId,Number,ProductId,OrderId")] OrderLn orderLn)
        {
            if (id != orderLn.OrderLnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderLn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderLnExists(orderLn.OrderLnId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderLn.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", orderLn.ProductId);
            return View(orderLn);
        }

        // GET: OrderLns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLn = await _context.OrderLns
                .Include(o => o.Order)
                .Include(o => o.Product)
                .SingleOrDefaultAsync(m => m.OrderLnId == id);
            if (orderLn == null)
            {
                return NotFound();
            }

            return View(orderLn);
        }

        // POST: OrderLns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderLn = await _context.OrderLns.SingleOrDefaultAsync(m => m.OrderLnId == id);
            _context.OrderLns.Remove(orderLn);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OrderLnExists(int id)
        {
            return _context.OrderLns.Any(e => e.OrderLnId == id);
        }
    }
}
