using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repo = new ExperienceRepository();
        // GET: Experience
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExpriences exp)
        {
            repo.TAdd(exp);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            TblExpriences t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            TblExpriences t = repo.Find(x => x.Id == id);
            return View(t);
        } 
        [HttpPost]
        public ActionResult GetExperience(TblExpriences p)
        {
            TblExpriences t = repo.Find(x => x.Id == p.Id);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}