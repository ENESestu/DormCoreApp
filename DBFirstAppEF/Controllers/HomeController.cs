using Microsoft.AspNetCore.Mvc;
using DBFirstAppEF.Data;
using DBFirstAppEF.Models;
using DBFirstAppEF.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DBFirstAppEF.Controllers
{

    public class HomeController : Controller
    {
        DormDatabaseContext dbContext = new DormDatabaseContext();// database ulaşması lazım db context 

        public ActionResult Index()
        {
            var dorms = dbContext.Dorms.ToList();
            return View(dorms);
        }
        //Get Dorm by name
        public async Task<IActionResult> GetByNameDorm(string key)
        {
            var dormsByName = dbContext.Dorms.Where(d => d.Name.Contains(key)).ToList();
            return PartialView(dormsByName);
        }
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            if (id == null)
            {
                return View(new Dorm());
            }
            else
            {
                var dormModel = await dbContext.Dorms.FindAsync(id);
                if (dormModel == null)
                {
                    return null;
                }
                return View(dormModel);
            }
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Name,Address,PhoneNumber,ImageFilePath,IsDeleted")] Dorm dorm)
        //{
        //    //if (id != dorm.Id)
        //    //{
        //    //    return NotFound();
        //    //}

        //    if (ModelState.IsValid)
        //    {
        //        if (id == 0)
        //        {
        //            // Create operation
        //            dbContext.Add(dorm);
        //            await dbContext.SaveChangesAsync();
        //        }
        //        else
        //        {
        //            //Update operation 

        //            try
        //            {
        //                dbContext.Update(dorm);
        //                await dbContext.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                return NotFound();
        //            }
        //        }

        //        //return RedirectToAction(nameof(Index));
        //        return Json(new { isValid = true, html = Helper.RenderRazorViewToSting(this, "_ViewAllDorm", dbContext.Dorms.ToList()) });
        //    }
        //    //return View(dorm);
        //    return Json(new { isValid = false, html = Helper.RenderRazorViewToSting(this, "AddOrEdit", dorm) });
        //}
    }


}
