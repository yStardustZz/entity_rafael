//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace entity_rafael.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Atleta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Atleta()
        {
            this.Esporte1 = new HashSet<Esporte>();
        }
    
        public int IdAtleta { get; set; }
        public string nome { get; set; }
        public string esporte { get; set; }
        public Nullable<int> idade { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Esporte> Esporte1 { get; set; }
    }
}