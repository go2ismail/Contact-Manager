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
    public class StatusPriorityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatusPriorityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StatusPriority
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusPriority.ToListAsync());
        }

        // GET: StatusPriority/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusPriority = await _context.StatusPriority
                .SingleOrDefaultAsync(m => m.StatusPriorityId == id);
            if (statusPriority == null)
            {
                return NotFound();
            }

            return View(statusPriority);
        }

        // GET: StatusPriority/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusPriority/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusPriorityId,StatusPriorityName,ColorCode")] StatusPriority statusPriority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusPriority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusPriority);
        }

        // GET: StatusPriority/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusPriority = await _context.StatusPriority.SingleOrDefaultAsync(m => m.StatusPriorityId == id);
            if (statusPriority == null)
            {
                return NotFound();
            }
            return View(statusPriority);
        }

        // POST: StatusPriority/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusPriorityId,StatusPriorityName,ColorCode")] StatusPriority statusPriority)
        {
            if (id != statusPriority.StatusPriorityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusPriority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusPriorityExists(statusPriority.StatusPriorityId))
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
            return View(statusPriority);
        }

        // GET: StatusPriority/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusPriority = await _context.StatusPriority
                .SingleOrDefaultAsync(m => m.StatusPriorityId == id);
            if (statusPriority == null)
            {
                return NotFound();
            }

            return View(statusPriority);
        }

        // POST: StatusPriority/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusPriority = await _context.StatusPriority.SingleOrDefaultAsync(m => m.StatusPriorityId == id);
            _context.StatusPriority.Remove(statusPriority);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusPriorityExists(int id)
        {
            return _context.StatusPriority.Any(e => e.StatusPriorityId == id);
        }
    }
}
