using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities1 database = new DbCvEntities1();
        // GET: Default
        public ActionResult Index()
        {

            var values = database.TblAbout.ToList();
            return View(values);
        }
        public PartialViewResult Experience()
        {
            var exp = database.TblExpriences.ToList();
            return PartialView(exp);
        }
        public PartialViewResult SocialMedia()
        {
            var sm = database.TblSocialMedia.Where(x=>x.Status==true).ToList();
            return PartialView(sm);
        }
        public PartialViewResult Education()
        {
            var education = database.TblEducation.ToList();
            return PartialView(education);
        }
        public PartialViewResult Skills()
        {
            var skills = database.TblSkills.ToList();
            return PartialView(skills);
        }
        public PartialViewResult Hobbies()
        {
            var hobbies = database.TblHobbies.ToList();
            return PartialView(hobbies);
        }
        public PartialViewResult Sertificates()
        {
            var sertificates = database.TblCertificates.ToList();
            return PartialView(sertificates);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(TblContact contact)
        {
            contact.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            database.TblContact.Add(contact);
            database.SaveChanges();
            return PartialView();
        }
        public PartialViewResult References()
        {
            var references = database.TblReferences.ToList();
            return PartialView(references);
        }
    }
}