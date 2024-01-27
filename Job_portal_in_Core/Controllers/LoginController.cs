using Job_portal_in_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job_portal_in_Core.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabaseContext context;

        public LoginController(DatabaseContext context)
        {
            this.context = context;
            
        }
        public IActionResult SingIn()

        {

            return View();
        }
        [HttpPost]
        public IActionResult SingIn(login obj)

        {
            if (ModelState.IsValid)
            {
                var data=context.Seekers.Where(a=>a.email==obj.email && a.password==obj.password ).FirstOrDefault();
                if (data!=null)
                {
                    HttpContext.Session.SetString("seekersession", obj.email);
                    return RedirectToAction("JobSeeker", "Dashboard");
                }
                else
                {
                    ViewBag.msg = "Login Failed";
                }
                var admindata=context.admins.Where(a=>a.admin_email==obj.email && a.admin_password==obj.password ).FirstOrDefault();
                if (admindata!=null)
                {
                    HttpContext.Session.SetString("adminsession", obj.email);
                    return RedirectToAction("dashboard", "Admin");
                }
                else
                {

                    ViewBag.msg = "Login Failed";
                }
                var d= context.Recruiter.Where(a => a.Company_email == obj.email && a.Company_password==obj.password).FirstOrDefault();
                if(d!=null) 
                {
                    HttpContext.Session.SetString("recruitersession", obj.email);
                    return RedirectToAction("JobRecruiter", "Dashboard");
                }
                else
                {
                    ViewBag.msg = "Login Failed";
                }


            }
            
                return View();
            

           
        }
        public IActionResult Logout()
        {
            if(HttpContext.Session.GetString("seekersession") != null)
            {
                HttpContext.Session.Remove("seekersession");
               
                return RedirectToAction("SingIn");
            }
            if(HttpContext.Session.GetString("recruitersession")!=null)
            {
                HttpContext.Session.Remove("recruitersession");
                return RedirectToAction("SingIn");
            }
            if(HttpContext.Session.GetString("adminsession")!=null)
            {
                HttpContext.Session.Remove("adminsession");
                return RedirectToAction("SingIn");
            }
            return RedirectToAction("SingIn");
        }
    }
}
