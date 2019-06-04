using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TP2_ASP.NET_Final_.Models;

namespace TP2_ASP.NET_Final_.Controllers
{
    public class LoginController : Controller
    {
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(HUser user,string ReturnUrl)
        {
            if (IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.UName, false);
                return Redirect(ReturnUrl);
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/ShowData/Multidata");
        }

        private bool IsValid(HUser user)
        {
            //Do DB work here
            return (user.UName=="test" && user.Password=="test");
        }
    }
}