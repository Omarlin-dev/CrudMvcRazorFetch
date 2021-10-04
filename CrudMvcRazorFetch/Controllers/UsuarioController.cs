using CrudMvcRazorFetch.Models;
using CrudMvcRazorFetch.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMvcRazorFetch.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
         [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModels model)
        {

            try
            {
                using (CrudMvcFetchEntities1 db = new CrudMvcFetchEntities1())
                {
                    var oUser = (from d in db.User
                                 where d.UserName.ToUpper() == model.userName.Trim().ToUpper() && d.Password.ToUpper() == model.pass.Trim().ToUpper()
                                 select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o Contraseña invalida";
                        return View();
                    }

                    Session["User"] = oUser;
                }

                return RedirectToAction("Index", "People");
            }
            catch (Exception ex)
            {
                return View();

            }

        }

        public ActionResult logof()
        {
            Session["User"] = null;

            return RedirectToAction("Login", "Usuario");
        }
    }
}