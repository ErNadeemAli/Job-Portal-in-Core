using Job_portal_in_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Job_portal_in_Core.Controllers
{
  
    public class DashboardController : Controller
    {
        private readonly DatabaseContext context;
      
        public DashboardController(DatabaseContext context)
        {
            this.context = context;
        }
        
        public IActionResult JobSeeker()

        {
            var IDD = HttpContext.Session.GetString("seekersession");

            if (IDD != null)
            {
                var data = context.Seekers.Where(a => a.email == IDD).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }
        } 
        public IActionResult EditJobSeeker(int id)

        {
            var IDD = HttpContext.Session.GetString("seekersession");

            if (IDD != null)
            {
                var data = context.Seekers.Find(id);
                return View(data);
            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }
        }
        [HttpPost]
        public IActionResult EditJobSeeker(JobSeeker obj)

        {
            var IDD = HttpContext.Session.GetString("seekersession");

            if (IDD != null)
            {
                context.Seekers.Entry(obj).State=EntityState.Modified;
               int i= context.SaveChanges();
                if(i > 0)
                {
                    TempData["mes"] = "Record Upated Successfully";
                }
                return RedirectToAction("JobSeeker");
            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }
        } 
        public IActionResult JobRecruiter()

        {
            var IDD=HttpContext.Session.GetString("recruitersession");
            
            if (IDD != null) 
            {
                var data = context.Recruiter.Where(a=>a.Company_email== IDD).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }
            


        }

        public IActionResult Changepassword()
        {
            return View();

        }
    }
}
