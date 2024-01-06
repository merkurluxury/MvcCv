using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Repositories;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
    public class EducationController : Controller
    {

        GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();
        // GET: Education
        
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult GetEducation(TblEducation p)
        {
            TblEducation t = repo.Find(x => x.Id == p.Id);
            t.Title = p.Title;
            t.Subtitle1 = p.Subtitle1;
            t.Subtitle2 = p.Subtitle2;
            t.Date = p.Date;
            t.GradeAverage = p.GradeAverage;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetEducation(int id)
        {
            TblEducation t = repo.Find(x => x.Id == id);
            return View(t);
        }
    }
}