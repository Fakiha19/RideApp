using CarHailingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarHailingApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblUser user)
        {
            RideAppEntities obj = new RideAppEntities();
            var count = obj.tblUsers.Where(x => x.UserName == user.UserName && x.Paasword == user.Paasword).Count();
            if (count == 0)
            {
                ViewBag.Msg = "Invalid User";
                return View();
            }
            else 
            {
                FormsAuthentication.SetAuthCookie(user.UserName,false);
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
        
    }
}