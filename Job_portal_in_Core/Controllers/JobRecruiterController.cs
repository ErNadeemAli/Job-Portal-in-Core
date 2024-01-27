using Job_portal_in_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job_portal_in_Core.Controllers
{
    public class JobRecruiterController : Controller
    {
        private readonly DatabaseContext context;
        public JobRecruiterController(DatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(JobRecruiter obj)

        {
            
            if(obj!=null)
            {
                context.Recruiter.Add(obj);
                int i =context.SaveChanges();
                if(i > 0)
                {
                    ModelState.Clear();
                    ViewBag.msg = "Data has been Saved SuccessFully !!";
                }
                else
                {
                    ViewBag.msg = "Data Not Saved !!";
                }
            }
            return View();
        }
    }
}
