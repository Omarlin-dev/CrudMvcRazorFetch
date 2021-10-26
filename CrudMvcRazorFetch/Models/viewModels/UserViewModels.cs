using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudMvcRazorFetch.Models.viewModels
{
    public class UserViewModels
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Nombre de Usuario")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Contrasena")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Id persona")]
        public int IdPeople { get; set; }
         
        public List<people> peopleUser { get; set; }

    }
}