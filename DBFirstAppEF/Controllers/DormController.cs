using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirstAppEF.Data;
using DBFirstAppEF.Models;
using DBFirstAppEF.Helpers;

namespace DBFirstAppEF.Controllers
{
    public class DormController : Controller
    {
        private readonly DormDatabaseContext _context;

        public DormController(DormDatabaseContext context)
        {
            _context = context;
        }

        // GET: Dorm
        public async Task<IActionResult> Index()
        {
            return _context.Dorms != null ?
                        View(await _context.Dorms.ToListAsync()) :
                        Problem("Entity set 'DormDatabaseContext.Dorms'  is null.");
        }
        public async Task<IActionResult> GetByNameDorm(string s)
        {
            Console.WriteLine(s);
            var dormsByName = _context.Dorms.Where(d => d.Name.Contains(s)).ToList();
            return View(dormsByName);
        }

        // GET: Dorm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dorms == null)
            {
                return NotFound();
            }

            var dorm = await _context.Dorms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dorm == null)
            {
                return NotFound();
            }

            return View(dorm);
        }

        // GET: Dorm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dorm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,PhoneNumber,ImageFilePath")] Dorm dorm)
        {
            if (ModelState.IsValid)
            {
                dorm.IsDeleted = "0";

                _context.Add(dorm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dorm);
        }

        //// GET: Dorm/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Dorms == null)
        //    {
        //        return NotFound();
        //    }

        //    var dorm = await _context.Dorms.FindAsync(id);
        //    if (dorm == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(dorm);
        //}
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            if (id == null)
            {
                return View(new Dorm());
            }
            else
            {
                var dormModel = await _context.Dorms.FindAsync(id);
                if (dormModel == null)
                {
                    return null;
                }
                return View(dormModel);
            }
            return View();
        }


        // POST: Dorm/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Name,Address,PhoneNumber,ImageFilePath,IsDeleted")] Dorm dorm)
        {
            //if (id != dorm.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                //Update operation 
                try
                {
                    _context.Update(dorm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DormExists(dorm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //return RedirectToAction(nameof(Index));
                return Json(new { isValid = true, html = Helper.RenderRazorViewToSting(this, "_ViewAllDorm", _context.Dorms.ToList()) });
            }
            //return View(dorm);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToSting(this, "AddOrEdit", dorm) });
        }

        //--------------------------------------------------------------------------------------------

        // POST: Dorm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        // Add Or Edit olarak yeniden yazdım yukarıda
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,PhoneNumber,ImageFilePath,IsDeleted")] Dorm dorm)
        //{
        //    if (id != dorm.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(dorm);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DormExists(dorm.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(dorm);
        //}

        // GET: Dorm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dorms == null)
            {
                return NotFound();
            }

            var dorm = await _context.Dorms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dorm == null)
            {
                return NotFound();
            }

            return View(dorm);
        }

        // POST: Dorm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dorms == null)
            {
                return Problem("Entity set 'DormDatabaseContext.Dorms'  is null.");
            }
            var dorm = await _context.Dorms.FindAsync(id);
            if (dorm != null)
            {
                _context.Dorms.Remove(dorm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DormExists(int id)
        {
            return (_context.Dorms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
