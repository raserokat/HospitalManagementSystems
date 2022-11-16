using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (HospitalManagementSystemEntities2 db = new HospitalManagementSystemEntities2())
                {
                    var obj=db.UserProfiles.Where(p => p.UserName == objUser.UserName && p.Password == objUser.Password).FirstOrDefault();
                if (obj != null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["UserName"]=obj.UserName.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }    
            }
            return View(objUser);
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserId"]!=null)
            {
                return View();
            }else
            {
                return RedirectToAction("Login");
            }

        }
    }
}