using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;


namespace MVCCV.Controllers
{
    public class SkillController : Controller
    {

        GenericRepository<TblSkills> repo = new GenericRepository<TblSkills>();
        // GET: Skill
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkills p)
        {

            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            TblSkills t = repo.Find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetSkill(int id)
        {
            TblSkills t = repo.Find(x => x.Id == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult GetSkill(TblSkills p)
        {
            TblSkills t = repo.Find(x => x.Id == p.Id);

            t.Skills = p.Skills;
            t.Rate = p.Rate;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}