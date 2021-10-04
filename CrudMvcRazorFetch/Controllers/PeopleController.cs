using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudMvcRazorFetch.Models;
using CrudMvcRazorFetch.Models.viewModels;

namespace CrudMvcRazorFetch.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult List()
        {
            List<peopleViewModels> lst;
            using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
            {
                lst = (from d in db.people
                       select new peopleViewModels
                       {
                           Id = d.id,
                           Nombre = d.name,
                           Apellido = d.lastName,
                           Edad = d.age,
                           FechaNacimiento = d.dateBird.Value

                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Save(peopleViewModels model)
        {
            try
            {
                using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
                {
                    people opeple = new people();

                    opeple.name = model.Nombre;
                    opeple.age = model.Edad;
                    opeple.lastName = model.Apellido;
                    opeple.dateBird = model.FechaNacimiento;

                    db.people.Add(opeple);
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
            peopleViewModels model = new peopleViewModels();

            using(CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
            {
                people opeple = db.people.Find(Id);
                model.Id = opeple.id;
                model.Nombre = opeple.name;
                model.Edad = opeple.age;
                model.Apellido = opeple.lastName;
                model.FechaNacimiento = opeple.dateBird.Value;
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Update(peopleViewModels model)
        {
            try
            {
                using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
                {
                    people opeple = db.people.Find(model.Id);

                    opeple.name = model.Nombre;
                    opeple.age = model.Edad;
                    opeple.lastName = model.Apellido;
                    opeple.dateBird = model.FechaNacimiento;

                    db.Entry(opeple).State = System.Data.Entity.EntityState.Modified;
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
                    people opeple = db.people.Find(Id);
                    
                    db.people.Remove(opeple);
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