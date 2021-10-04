using System.Web;
using System.Web.Mvc;
using CrudMvcRazorFetch.Filters;
namespace CrudMvcRazorFetch
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerificarSesion());
        }
    }
}
