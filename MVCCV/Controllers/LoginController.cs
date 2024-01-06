using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities1 database = new DbCvEntities1();
            var user = database.TblAdmin.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (user !=null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["UserName"] = user.UserName.ToString();
                return RedirectToAction("Index", "Experience");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}