using Ft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ft.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        FMSEntities context = new FMSEntities();
        // GET: Login



        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string UserName, string Password, string returnUrl)
        {
            //var match_value = context.Users.FirstOrDefault(uname => uname.UserName == user.UserName  && uname.Password == user.Password);
            var match_value = context.Users.FirstOrDefault(uname => uname.UserName == UserName && uname.Password == Password);



            if (match_value != null)
            {
                FormsAuthentication.SetAuthCookie(UserName, false);



                



                return RedirectToAction("Index", "Home");


            }
            else
            {
                ViewBag.message = "Empty Field or wrong Info";



                return View();
            }



        }



        public ActionResult Logout()
        {
           

            FormsAuthentication.SignOut();



            return Redirect("/Login");

        }
    }
}