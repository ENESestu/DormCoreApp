using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirstAppEF.Data;
using DBFirstAppEF.Models;

namespace DBFirstAppEF.Controllers
{
    public class AuthoritieController : Controller
    {
        private readonly DormDatabaseContext _context;

        public AuthoritieController(DormDatabaseContext context)
        {
            _context = context;
        }

        // GET: Authoritie
        public async Task<IActionResult> Index()
        {
            var dormDatabaseContext = _context.Authorities.Include(a => a.Role).Include(a => a.User);
            return View(await dormDatabaseContext.ToListAsync());
        }

        // GET: Authoritie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Authorities == null)
            {
                return NotFound();
            }

            var authority = await _context.Authorities
                .Include(a => a.Role)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authority == null)
            {
                return NotFound();
            }

            return View(authority);
        }

        // GET: Authoritie/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Authoritie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,RoleId,UserId")] Authority authority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", authority.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", authority.UserId);
            return View(authority);
        }

        // GET: Authoritie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authorities == null)
            {
                return NotFound();
            }

            var authority = await _context.Authorities.FindAsync(id);
            if (authority == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", authority.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", authority.UserId);
            return View(authority);
        }

        // POST: Authoritie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,RoleId,UserId")] Authority authority)
        {
            if (id != authority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorityExists(authority.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", authority.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", authority.UserId);
            return View(authority);
        }

        // GET: Authoritie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authorities == null)
            {
                return NotFound();
            }

            var authority = await _context.Authorities
                .Include(a => a.Role)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authority == null)
            {
                return NotFound();
            }

            return View(authority);
        }

        // POST: Authoritie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Authorities == null)
            {
                return Problem("Entity set 'DormDatabaseContext.Authorities'  is null.");
            }
            var authority = await _context.Authorities.FindAsync(id);
            if (authority != null)
            {
                _context.Authorities.Remove(authority);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorityExists(int id)
        {
          return (_context.Authorities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
