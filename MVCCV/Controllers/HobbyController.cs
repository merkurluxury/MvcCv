using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class HobbyController : Controller
    {
        GenericRepository<TblHobbies> repo = new GenericRepository<TblHobbies>();
        // GET: Hobby
        [HttpGet]
        public ActionResult Index()
        {
            var hobby = repo.List();
            return View(hobby);
        }
        [HttpPost]
        public ActionResult Index(TblHobbies p)
        {
            //TblHobbies t = new TblHobbies();
            var t = repo.Find(x => x.Id == 1);
            t.Description1 = p.Description1;
            t.Description2 = p.Description2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
       
    }
}