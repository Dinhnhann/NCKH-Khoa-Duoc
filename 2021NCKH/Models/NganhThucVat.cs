//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _2021NCKH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NganhThucVat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NganhThucVat()
        {
            this.LopThucVats = new HashSet<LopThucVat>();
        }
    
        public int MaNganhThucVat { get; set; }
        public string TenNganhThucVat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopThucVat> LopThucVats { get; set; }
    }
}