using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirstAppEF.Data;
using DBFirstAppEF.Models;

namespace DBFirstAppEF.Controllers
{
    public class AccommodationController : Controller
    {
        private readonly DormDatabaseContext _context;

        public AccommodationController(DormDatabaseContext context)
        {
            _context = context;
        }

        // GET: Accommodation
        public async Task<IActionResult> Index()
        {
            var dormDatabaseContext = _context.Accommodations.Include(a => a.Dorm).Include(a => a.RoomNoNavigation).Include(a => a.User);
            return View(await dormDatabaseContext.ToListAsync());
        }

        // GET: Accommodation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accommodations == null)
            {
                return NotFound();
            }

            var accommodation = await _context.Accommodations
                .Include(a => a.Dorm)
                .Include(a => a.RoomNoNavigation)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accommodation == null)
            {
                return NotFound();
            }

            return View(accommodation);
        }

        // GET: Accommodation/Create
        public IActionResult Create()
        {
            ViewData["DormId"] = new SelectList(_context.Dorms, "Id", "Id");
            ViewData["RoomNo"] = new SelectList(_context.Rooms, "RoomNo", "RoomNo");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Accommodation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateStart,DateEnd,IsDeleted,DormId,RoomNo,UserId")] Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accommodation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DormId"] = new SelectList(_context.Dorms, "Id", "Id", accommodation.DormId);
            ViewData["RoomNo"] = new SelectList(_context.Rooms, "RoomNo", "RoomNo", accommodation.RoomNo);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", accommodation.UserId);
            return View(accommodation);
        }

        // GET: Accommodation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accommodations == null)
            {
                return NotFound();
            }

            var accommodation = await _context.Accommodations.FindAsync(id);
            if (accommodation == null)
            {
                return NotFound();
            }
            ViewData["DormId"] = new SelectList(_context.Dorms, "Id", "Id", accommodation.DormId);
            ViewData["RoomNo"] = new SelectList(_context.Rooms, "RoomNo", "RoomNo", accommodation.RoomNo);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", accommodation.UserId);
            return View(accommodation);
        }

        // POST: Accommodation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateStart,DateEnd,IsDeleted,DormId,RoomNo,UserId")] Accommodation accommodation)
        {
            if (id != accommodation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accommodation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccommodationExists(accommodation.Id))
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
            ViewData["DormId"] = new SelectList(_context.Dorms, "Id", "Id", accommodation.DormId);
            ViewData["RoomNo"] = new SelectList(_context.Rooms, "RoomNo", "RoomNo", accommodation.RoomNo);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", accommodation.UserId);
            return View(accommodation);
        }

        // GET: Accommodation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accommodations == null)
            {
                return NotFound();
            }

            var accommodation = await _context.Accommodations
                .Include(a => a.Dorm)
                .Include(a => a.RoomNoNavigation)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accommodation == null)
            {
                return NotFound();
            }

            return View(accommodation);
        }

        // POST: Accommodation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accommodations == null)
            {
                return Problem("Entity set 'DormDatabaseContext.Accommodations'  is null.");
            }
            var accommodation = await _context.Accommodations.FindAsync(id);
            if (accommodation != null)
            {
                _context.Accommodations.Remove(accommodation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccommodationExists(int id)
        {
          return (_context.Accommodations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
