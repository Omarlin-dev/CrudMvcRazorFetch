using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudMvcRazorFetch.Models.viewModels
{
    public class UserViewModels
    {
        public string userName { get; set; }
        [DataType(DataType.Password)]
        public string pass { get; set; }
    }
}