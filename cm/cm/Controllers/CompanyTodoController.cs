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
    public class CompanyTodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyTodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyTodo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Todo.Include(t => t.Company).Include(t => t.CreateBy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompanyTodo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo
                .Include(t => t.Company)
                .Include(t => t.CreateBy)
                .SingleOrDefaultAsync(m => m.TodoId == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: CompanyTodo/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName");
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: CompanyTodo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TodoId,TodoName,TodoCompleteDate,Tag,CompanyId,CreateAt,CreateById")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", todo.CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id", todo.CreateById);
            return View(todo);
        }

        // GET: CompanyTodo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo.SingleOrDefaultAsync(m => m.TodoId == id);
            if (todo == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", todo.CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id", todo.CreateById);
            return View(todo);
        }

        // POST: CompanyTodo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TodoId,TodoName,TodoCompleteDate,Tag,CompanyId,CreateAt,CreateById")] Todo todo)
        {
            if (id != todo.TodoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(todo.TodoId))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyName", todo.CompanyId);
            ViewData["CreateById"] = new SelectList(_context.Users, "Id", "Id", todo.CreateById);
            return View(todo);
        }

        // GET: CompanyTodo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo
                .Include(t => t.Company)
                .Include(t => t.CreateBy)
                .SingleOrDefaultAsync(m => m.TodoId == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: CompanyTodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todo = await _context.Todo.SingleOrDefaultAsync(m => m.TodoId == id);
            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.TodoId == id);
        }
    }
}
