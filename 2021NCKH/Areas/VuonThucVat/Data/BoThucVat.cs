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
    
    public partial class BoThucVat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BoThucVat()
        {
            this.HoThucVats = new HashSet<HoThucVat>();
        }
    
        public int MaBoThucVat { get; set; }
        public string TenBoThucVat { get; set; }
        public int MaPhanLopThucVat { get; set; }
    
        public virtual PhanLopThucVat PhanLopThucVat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoThucVat> HoThucVats { get; set; }
    }
}
