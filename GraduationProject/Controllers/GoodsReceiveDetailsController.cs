using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GraduationProject.Data;
using GraduationProject.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace GraduationProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GoodsReceiveDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsReceiveDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsReceiveDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GoodsReceiveDetail.Include(g => g.GoodsReceive).Include(g => g.Product).Include(g => g.Warehouse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GoodsReceiveDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsReceiveDetail = await _context.GoodsReceiveDetail
                .Include(g => g.GoodsReceive)
                .Include(g => g.Product)
                .Include(g => g.Warehouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsReceiveDetail == null)
            {
                return NotFound();
            }

            return View(goodsReceiveDetail);
        }

        // GET: GoodsReceiveDetails/Create
        public IActionResult Create()
        {
            ViewData["GoodsReceiveId"] = new SelectList(_context.GoodsReceive, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "Id", "Name");
            return View();
        }

        // POST: GoodsReceiveDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodsReceiveId,ProductId,WarehouseId,Quantity,Id,RowGuid,CreatedByUserId,CreatedAtUtc,UpdatedByUserId,UpdatedAtUtc,IsNotDeleted")] GoodsReceiveDetail goodsReceiveDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsReceiveDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GoodsReceiveId"] = new SelectList(_context.GoodsReceive, "Id", "Id", goodsReceiveDetail.GoodsReceiveId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", goodsReceiveDetail.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "Id", "Name", goodsReceiveDetail.WarehouseId);
            return View(goodsReceiveDetail);
        }

        // GET: GoodsReceiveDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsReceiveDetail = await _context.GoodsReceiveDetail.FindAsync(id);
            if (goodsReceiveDetail == null)
            {
                return NotFound();
            }
            ViewData["GoodsReceiveId"] = new SelectList(_context.GoodsReceive, "Id", "Id", goodsReceiveDetail.GoodsReceiveId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", goodsReceiveDetail.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "Id", "Name", goodsReceiveDetail.WarehouseId);
            return View(goodsReceiveDetail);
        }

        // POST: GoodsReceiveDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoodsReceiveId,ProductId,WarehouseId,Quantity,Id,RowGuid,CreatedByUserId,CreatedAtUtc,UpdatedByUserId,UpdatedAtUtc,IsNotDeleted")] GoodsReceiveDetail goodsReceiveDetail)
        {
            if (id != goodsReceiveDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsReceiveDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsReceiveDetailExists(goodsReceiveDetail.Id))
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
            ViewData["GoodsReceiveId"] = new SelectList(_context.GoodsReceive, "Id", "Id", goodsReceiveDetail.GoodsReceiveId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", goodsReceiveDetail.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouse, "Id", "Name", goodsReceiveDetail.WarehouseId);
            return View(goodsReceiveDetail);
        }

        // GET: GoodsReceiveDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsReceiveDetail = await _context.GoodsReceiveDetail
                .Include(g => g.GoodsReceive)
                .Include(g => g.Product)
                .Include(g => g.Warehouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsReceiveDetail == null)
            {
                return NotFound();
            }

            return View(goodsReceiveDetail);
        }

        // POST: GoodsReceiveDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodsReceiveDetail = await _context.GoodsReceiveDetail.FindAsync(id);
            if (goodsReceiveDetail != null)
            {
                _context.GoodsReceiveDetail.Remove(goodsReceiveDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsReceiveDetailExists(int id)
        {
            return _context.GoodsReceiveDetail.Any(e => e.Id == id);
        }
    }
}
