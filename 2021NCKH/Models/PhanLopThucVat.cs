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
    
    public partial class PhanLopThucVat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhanLopThucVat()
        {
            this.BoThucVats = new HashSet<BoThucVat>();
        }
    
        public int MaPhanLopThucVat { get; set; }
        public string TenPhanLopThucVat { get; set; }
        public int MaLopThucVat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoThucVat> BoThucVats { get; set; }
        public virtual LopThucVat LopThucVat { get; set; }
    }
}
