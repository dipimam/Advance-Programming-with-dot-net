//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tree_Plantation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class volunteer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public volunteer()
        {
            this.assigneds = new HashSet<assigned>();
            this.requests = new HashSet<request>();
        }
    
        public int v_id { get; set; }
        public string v_name { get; set; }
        public string v_email { get; set; }
        public Nullable<int> v_phone { get; set; }
        public string v_address { get; set; }
        public string v_image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assigned> assigneds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }
    }
}
