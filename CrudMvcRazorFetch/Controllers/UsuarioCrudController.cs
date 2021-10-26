using CrudMvcRazorFetch.Models;
using CrudMvcRazorFetch.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMvcRazorFetch.Controllers
{
    public class UsuarioCrudController : Controller
    {
        // GET: UsuarioCrud
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<UserViewModels> lst;
            using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
            {
                lst = (from d in db.User
                       select new UserViewModels
                       {
                           Id = d.Id,
                           UserName = d.UserName,
                           Password = d.Password,
                           IdPeople = d.IdPeople

                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult New()
        {
            UserViewModels ouser = new UserViewModels();
            List<people> lst;
            using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
            {
                lst = db.people.ToList();
            }
            ouser.peopleUser = lst;

            return View(ouser);
        }

        [HttpPost]
        public ActionResult Save(UserViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View("New",model);
            }

            try
            {
                using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
                {
                    User ouser = new User();

                    ouser.UserName = model.UserName;
                    ouser.Password = model.Password;
                    ouser.IdPeople = model.IdPeople;

                    db.User.Add(ouser);
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Edit(int Id)
        {
            UserViewModels model = new UserViewModels();
            List<people> lst;
           

            using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
            {
                User ouser = db.User.Find(Id);
                lst = db.people.ToList();

                model.Id = ouser.Id;
                model.UserName = ouser.UserName;
                model.Password = ouser.Password;
                model.IdPeople = ouser.IdPeople;
                model.peopleUser = lst;
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            try
            {
                using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
                {
                    User ouser = db.User.Find(model.Id);

                    ouser.UserName = model.UserName;
                    ouser.Password = model.Password;
                    ouser.IdPeople = model.IdPeople;


                    db.Entry(ouser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
                {
                    User ouser = db.User.Find(Id);

                    db.User.Remove(ouser);
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}