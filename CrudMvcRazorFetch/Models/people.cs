//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrudMvcRazorFetch.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class people
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public people()
        {
            this.User = new HashSet<User>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<System.DateTime> dateBird { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }
}