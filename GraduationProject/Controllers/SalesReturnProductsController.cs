using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GraduationProject.Data;
using GraduationProject.Models.Entities;

namespace GraduationProject.Controllers
{
    public class SalesReturnProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesReturnProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesReturnProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SalesReturnProduct.Include(s => s.Product).Include(s => s.SalesReturn);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SalesReturnProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReturnProduct = await _context.SalesReturnProduct
                .Include(s => s.Product)
                .Include(s => s.SalesReturn)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesReturnProduct == null)
            {
                return NotFound();
            }

            return View(salesReturnProduct);
        }

        // GET: SalesReturnProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            ViewData["SalesReturnId"] = new SelectList(_context.SalesReturn, "Id", "Id");
            return View();
        }

        // POST: SalesReturnProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,Reason,SalesReturnId,ProductId,RowGuid,CreatedByUserId,CreatedAtUtc,UpdatedByUserId,UpdatedAtUtc,IsNotDeleted")] SalesReturnProduct salesReturnProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesReturnProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", salesReturnProduct.ProductId);
            ViewData["SalesReturnId"] = new SelectList(_context.SalesReturn, "Id", "Id", salesReturnProduct.SalesReturnId);
            return View(salesReturnProduct);
        }

        // GET: SalesReturnProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReturnProduct = await _context.SalesReturnProduct.FindAsync(id);
            if (salesReturnProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", salesReturnProduct.ProductId);
            ViewData["SalesReturnId"] = new SelectList(_context.SalesReturn, "Id", "Id", salesReturnProduct.SalesReturnId);
            return View(salesReturnProduct);
        }

        // POST: SalesReturnProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Reason,SalesReturnId,ProductId,RowGuid,CreatedByUserId,CreatedAtUtc,UpdatedByUserId,UpdatedAtUtc,IsNotDeleted")] SalesReturnProduct salesReturnProduct)
        {
            if (id != salesReturnProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesReturnProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesReturnProductExists(salesReturnProduct.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", salesReturnProduct.ProductId);
            ViewData["SalesReturnId"] = new SelectList(_context.SalesReturn, "Id", "Id", salesReturnProduct.SalesReturnId);
            return View(salesReturnProduct);
        }

        // GET: SalesReturnProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesReturnProduct = await _context.SalesReturnProduct
                .Include(s => s.Product)
                .Include(s => s.SalesReturn)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesReturnProduct == null)
            {
                return NotFound();
            }

            return View(salesReturnProduct);
        }

        // POST: SalesReturnProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesReturnProduct = await _context.SalesReturnProduct.FindAsync(id);
            if (salesReturnProduct != null)
            {
                _context.SalesReturnProduct.Remove(salesReturnProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesReturnProductExists(int id)
        {
            return _context.SalesReturnProduct.Any(e => e.Id == id);
        }
    }
}
