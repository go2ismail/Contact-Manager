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
    public class StatusDealController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatusDealController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StatusDeal
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusDeal.ToListAsync());
        }

        // GET: StatusDeal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusDeal = await _context.StatusDeal
                .SingleOrDefaultAsync(m => m.StatusDealId == id);
            if (statusDeal == null)
            {
                return NotFound();
            }

            return View(statusDeal);
        }

        // GET: StatusDeal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusDeal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusDealId,StatusDealName,Weight")] StatusDeal statusDeal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusDeal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusDeal);
        }

        // GET: StatusDeal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusDeal = await _context.StatusDeal.SingleOrDefaultAsync(m => m.StatusDealId == id);
            if (statusDeal == null)
            {
                return NotFound();
            }
            return View(statusDeal);
        }

        // POST: StatusDeal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusDealId,StatusDealName,Weight")] StatusDeal statusDeal)
        {
            if (id != statusDeal.StatusDealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusDeal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusDealExists(statusDeal.StatusDealId))
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
            return View(statusDeal);
        }

        // GET: StatusDeal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusDeal = await _context.StatusDeal
                .SingleOrDefaultAsync(m => m.StatusDealId == id);
            if (statusDeal == null)
            {
                return NotFound();
            }

            return View(statusDeal);
        }

        // POST: StatusDeal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusDeal = await _context.StatusDeal.SingleOrDefaultAsync(m => m.StatusDealId == id);
            _context.StatusDeal.Remove(statusDeal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusDealExists(int id)
        {
            return _context.StatusDeal.Any(e => e.StatusDealId == id);
        }
    }
}
