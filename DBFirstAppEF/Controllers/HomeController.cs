using Microsoft.AspNetCore.Mvc;
using DBFirstAppEF.Data;

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
    }


}
