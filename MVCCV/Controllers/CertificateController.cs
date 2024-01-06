using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class CertificateController : Controller
    {
        GenericRepository<TblCertificates> repo = new GenericRepository<TblCertificates>();
        // GET: Certificate
        public ActionResult Index()
        {
            var cert = repo.List();
            return View(cert);
        }
        [HttpGet]
        public ActionResult GetCertificate(int id)
        {
            var t = repo.Find(x => x.Id == id);
            ViewBag.d1 = id;
            return View(t);
        }
        [HttpPost]
        public ActionResult GetCertificate(TblCertificates p)
        {
            var t = repo.Find(x => x.Id == p.Id);
            t.Description = p.Description;
            t.Photo = p.Photo;
            t.Date = p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(TblCertificates p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var t = repo.Find(x => x.Id == id);
           
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}