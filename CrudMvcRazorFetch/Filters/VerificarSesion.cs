using CrudMvcRazorFetch.Controllers;
using CrudMvcRazorFetch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMvcRazorFetch.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        private User user; 

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                user = (User)HttpContext.Current.Session["User"];

                if(user == null)
                {
                    if(filterContext.Controller is UsuarioController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Usuario/Login");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Usuario/Login");
            }

        }
    }
}