using Job_portal_in_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            var IDD = HttpContext.Session.GetString("seekersession");
            var IDDD = HttpContext.Session.GetString("recruitersession");
            var Adminsession = HttpContext.Session.GetString("adminsession");

            if (IDD != null)
            {
               ViewBag.temp = "~/views/shared/_layout_dashboard_Seeker.cshtml";
            }
            else if (IDDD != null)
            {
                ViewBag.temp = "~/views/shared/_layout_dashboard_recruiter.cshtml";
            } 
            else if (Adminsession != null)
            {
                ViewBag.temp = "~/views/shared/_layout_dashboard.cshtml";
            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }
            return View();

        }
        [HttpPost]
        public IActionResult Changepassword(ChangePassword obj)

        {
            
            var IDD = HttpContext.Session.GetString("seekersession");
            var IDDD = HttpContext.Session.GetString("recruitersession");
            var Adminsession= HttpContext.Session.GetString("adminsession");


            if (IDD != null)
            {
                // seeker part
                ViewBag.temp = "~/views/shared/_layout_dashboard_Seeker.cshtml";
                if (ModelState.IsValid)
                {
                    var mydata = context.Seekers.Where(a=> a.email== IDD).FirstOrDefault();
                    if (obj.newPassword == obj.conPassword)
                    {
                        if ( mydata.password == obj.oldPassword)
                            
                        {
                            mydata.password = obj.conPassword;
                            context.Seekers.Entry(mydata).State = EntityState.Modified;
                            context.SaveChanges();
                            TempData["mes"] = "Password has been Updated!";
                            return RedirectToAction("JobSeeker", "Dashboard");
                        }
                        else
                        {
                            ViewBag.msg = "Old PassWord Do Not Match";
                            return View();
                        }

                    }
                    else
                    {
                        ViewBag.msg = "Confirm PassWord Do Not Match";
                        return View();

                    }

                }
             


                
            }
            // end seeker part
            else if (IDDD != null)
            {
                ViewBag.temp = "~/views/shared/_layout_dashboard_recruiter.cshtml";
                if (ModelState.IsValid)
                {
                    var mydata = context.Recruiter.Where(a=> a.Company_email==IDDD).FirstOrDefault();
                    if (obj.newPassword == obj.conPassword)
                    {
                        if (obj.oldPassword == mydata.Company_password)
                            
                        {
                            mydata.Company_password = obj.conPassword;
                            context.Recruiter.Entry(mydata).State = EntityState.Modified;
                            context.SaveChanges();
                            TempData["mes"] = "Password has been Updated!";
                            return RedirectToAction("JobRecruiter", "Dashboard");
                        }
                        else
                        {
                            ViewBag.msg = "Old PassWord Do Not Match";
                            return View();
                        }

                    }
                    else
                    {
                        ViewBag.msg = "Confirm PassWord Do Not Match";
                        return View();

                    }

                }
             


                
            }
            // end recruiter part
            else if (Adminsession != null)
            {
                ViewBag.temp = "~/views/shared/_layout_dashboard.cshtml";
                if (ModelState.IsValid)
                {
                    var mydata = context.admins.Where(a=> a.admin_email==IDDD).FirstOrDefault();
                    if (obj.newPassword == obj.conPassword)
                    {
                        if (obj.oldPassword == mydata.admin_password)
                            
                        {
                            mydata.admin_password = obj.conPassword;
                            context.admins.Entry(mydata).State = EntityState.Modified;
                            context.SaveChanges();
                            TempData["mes"] = "Password has been Updated!";
                            return RedirectToAction("dashboard", "admin");
                        }
                        else
                        {
                            ViewBag.msg = "Old PassWord Do Not Match";
                            return View();
                        }

                    }
                    else
                    {
                        ViewBag.msg = "Confirm PassWord Do Not Match";
                        return View();

                    }

                }
             


                
            }
            
           
                return RedirectToAction("singIn", "Login");           
            

        }
    }
}
