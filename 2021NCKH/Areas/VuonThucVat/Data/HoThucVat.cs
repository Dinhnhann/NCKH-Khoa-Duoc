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
    
    public partial class HoThucVat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoThucVat()
        {
            this.ChiThucVats = new HashSet<ChiThucVat>();
        }
    
        public int MaHoThucVat { get; set; }
        public string TenHoThucVat { get; set; }
        public int MaBoThucVat { get; set; }
    
        public virtual BoThucVat BoThucVat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiThucVat> ChiThucVats { get; set; }
    }
}