using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class AboutMeController : Controller
    {
        GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
        // GET: Hobby
        [HttpGet]
        public ActionResult Index()
        {
            var hobby = repo.List();
            return View(hobby);
        }
        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            //TblHobbies t = new TblHobbies();
            var t = repo.Find(x => x.Id == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Mail = p.Mail;
            t.Description = p.Description;
            t.Description2 = p.Description2;
            t.Photo = p.Photo;
            t.PhoneNumber = p.PhoneNumber;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}