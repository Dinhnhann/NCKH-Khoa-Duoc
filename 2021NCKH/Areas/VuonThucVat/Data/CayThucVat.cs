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
    
    public partial class CayThucVat
    {
        public int ID { get; set; }
        public string TenVietNam { get; set; }
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        public string BoPhanDung { get; set; }
        public string ThanhPhanHoaHoc { get; set; }
        public string TacDungDuocLy { get; set; }
        public string CongDung { get; set; }
        public string CachDung { get; set; }
        public string LieuDung { get; set; }
        public Nullable<int> Loai { get; set; }
    
        public virtual Loai Loai1 { get; set; }
    }
}
