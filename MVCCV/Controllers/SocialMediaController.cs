using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;
namespace MVCCV.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<TblSocialMedia> repo = new GenericRepository<TblSocialMedia>();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var data = repo.List();
            return View(data);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var account = repo.Find(x => x.Id == id);
            return View(account);
        }
        [HttpPost]
        public ActionResult Edit(TblSocialMedia p)
        {
            var account = repo.Find(x => x.Id == p.Id);
            account.SocialMediaName = p.SocialMediaName;
            account.Status = true;
            account.Link = p.Link;
            account.Icon = p.Icon;
            repo.TUpdate(account);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var t = repo.Find(x => x.Id == id);
            t.Status = false;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }


    }
}