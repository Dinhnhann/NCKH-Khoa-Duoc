//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _2021NCKH.Areas.VuonThucVat.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loai()
        {
            this.CayThucVats = new HashSet<CayThucVat>();
        }
    
        public int ID { get; set; }
        public string TenLoai { get; set; }
        public Nullable<int> Chi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CayThucVat> CayThucVats { get; set; }
        public virtual Chi Chi1 { get; set; }
    }
}
