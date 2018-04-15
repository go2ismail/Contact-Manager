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
    public class CompanyContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyContact
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Contact.Include(c => c.Company).Include(c => c.CreateBy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompanyContact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .Include(c => c.Company)
                .Include(c => c.CreateBy)
                .SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: CompanyContact/Create
        public IActionResult Create(int CompanyId)
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id");
            Contact contact = new Contact();
            contact.CompanyId = CompanyId;
            return View(contact);
        }

        // POST: CompanyContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,ContactName,Title,CompanyId,Description,Tag,Email,MobilePhone,WorkPhone,HomePhone,MailingStreet,MailingCity,MailingState,MailingCountry,MailingZipCode,CreateAt,CreateById")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Company", new { Id = contact.CompanyId });
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", contact.CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id", contact.CreateById);
            return View(contact);
        }

        // GET: CompanyContact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", contact.CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id", contact.CreateById);
            return View(contact);
        }

        // POST: CompanyContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,ContactName,Title,CompanyId,Description,Tag,Email,MobilePhone,WorkPhone,HomePhone,MailingStreet,MailingCity,MailingState,MailingCountry,MailingZipCode,CreateAt,CreateById")] Contact contact)
        {
            if (id != contact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactId))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", contact.CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id", contact.CreateById);
            return View(contact);
        }

        // GET: CompanyContact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .Include(c => c.Company)
                .Include(c => c.CreateBy)
                .SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: CompanyContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }
    }
}
