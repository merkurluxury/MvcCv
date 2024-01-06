using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Repositories;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        
        public ActionResult Index()
        {
            var list = repo.List();

            return View(list);
        }
        public ActionResult DeleteAdmin(int id)
        {
            var t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            var t = repo.Find(x => x.Id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetAdmin(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.Id == p.Id);
            t.UserName = p.UserName;
            t.Password = p.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAdmin(TblAdmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");

        }
    }
}