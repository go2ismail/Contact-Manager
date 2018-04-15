using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cm.Data;
using cm.Models;

namespace cm.Controllers
{
    public class DealController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DealController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deal
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Deal.Include(d => d.Company).Include(d => d.CreateBy).Include(d => d.DealOwner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Deal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deal
                .Include(d => d.Company)
                .Include(d => d.CreateBy)
                .Include(d => d.DealOwner)
                .SingleOrDefaultAsync(m => m.DealId == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // GET: Deal/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName");
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DealOwnerId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Deal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DealId,DealName,CompanyId,ExpectedClosingDate,DealOwnerId,DealValue,Description,Tag,IsWon,CreateAt,CreateById")] Deal deal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", deal.CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id", deal.CreateById);
            ViewData["DealOwnerId"] = new SelectList(_context.Users, "Id", "Id", deal.DealOwnerId);
            return View(deal);
        }

        // GET: Deal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deal.SingleOrDefaultAsync(m => m.DealId == id);
            if (deal == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", deal.CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id", deal.CreateById);
            ViewData["DealOwnerId"] = new SelectList(_context.Users, "Id", "Id", deal.DealOwnerId);
            return View(deal);
        }

        // POST: Deal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DealId,DealName,CompanyId,ExpectedClosingDate,DealOwnerId,DealValue,Description,Tag,IsWon,CreateAt,CreateById")] Deal deal)
        {
            if (id != deal.DealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealExists(deal.DealId))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", deal.CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id", deal.CreateById);
            ViewData["DealOwnerId"] = new SelectList(_context.Users, "Id", "Id", deal.DealOwnerId);
            return View(deal);
        }

        // GET: Deal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deal = await _context.Deal
                .Include(d => d.Company)
                .Include(d => d.CreateBy)
                .Include(d => d.DealOwner)
                .SingleOrDefaultAsync(m => m.DealId == id);
            if (deal == null)
            {
                return NotFound();
            }

            return View(deal);
        }

        // POST: Deal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deal = await _context.Deal.SingleOrDefaultAsync(m => m.DealId == id);
            _context.Deal.Remove(deal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealExists(int id)
        {
            return _context.Deal.Any(e => e.DealId == id);
        }
    }
}
