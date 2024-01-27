using Microsoft.AspNetCore.Mvc;
using Job_portal_in_Core.Models;

namespace Job_portal_in_Core.Controllers
{
    
    public class JobseekerController : Controller
    {
        private readonly DatabaseContext context;
        public JobseekerController(DatabaseContext context)
        {
            this.context = context;

        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(JobSeeker obj)
        {
            if (obj != null)
            {
                context.Seekers.Add(obj);
                int i=context.SaveChanges();
                if (i > 0)
                {
                    ModelState.Clear();
                    ViewBag.msg = "Data has been saved SuccessFully !";
                }
                else
                {
                    ViewBag.msg = "Data not Saved !";
                }
            }
            return View();
        }
    }
}
