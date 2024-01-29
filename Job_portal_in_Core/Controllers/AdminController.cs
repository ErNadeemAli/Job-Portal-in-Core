using Job_portal_in_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job_portal_in_Core.Controllers
{
    public class AdminController : Controller
    {
        private readonly DatabaseContext _db;
        public AdminController(DatabaseContext db)
        {
            this._db = db;
        }
        public IActionResult dashboard()

        {
            if(HttpContext.Session.GetString("adminsession")!=null)
            {
                var data = _db.admins.ToList();
                return View(data);

            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }

            
        }
        public IActionResult JobRecruiter()
        {
            if (HttpContext.Session.GetString("adminsession") != null)
            {
                var data = _db.Recruiter.ToList();
                return View(data);

            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }
            
            
        } 
        public IActionResult DeleteJobRecruiter(int id)
        {
            if (HttpContext.Session.GetString("adminsession") != null)
            {
                var data = _db.Recruiter.Find(id);
                _db.Recruiter.Remove(data);
               int i =_db.SaveChanges();
                if (i > 0) 
                {
                    TempData["mes"] = "Record Has Been Deleted";
                }
                return RedirectToAction("JobRecruiter");

            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }
            
            
        } 
        public IActionResult JobSeeker()
        {
            if (HttpContext.Session.GetString("adminsession") != null)
            {
                var data = _db.Seekers.ToList();
                return View(data);

            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }
            
            
        }
        public IActionResult DeleteJobSeeker(int id)
        {
            if (HttpContext.Session.GetString("adminsession") != null)
            {
                var data = _db.Seekers.Find(id);
                _db.Seekers.Remove(data);
                int i = _db.SaveChanges();
                if(i > 0)
                {
                    TempData["mes"] = "Recored Deleted Successfully";
                    
                }
                return RedirectToAction("JobSeeker");


            }
            else
            {
                return RedirectToAction("singIn", "Login");
            }
            
            
        }
        public IActionResult Country()
        {
            
            return View();
     
        
        }
        [HttpPost]
        public IActionResult Country(Country_tbl _Tbl)
        {
            if (ModelState.IsValid)
            {
                _db.Country_tbl.Add(_Tbl);
                int i=_db.SaveChanges();
                if( i > 0)
                {
                    ModelState.Clear();
                    ViewBag.mes = "New Country Added";
                }
            }
            return View();
            
            
            
        }
        
    }
}
