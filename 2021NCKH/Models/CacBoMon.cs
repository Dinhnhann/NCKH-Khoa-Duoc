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
<<<<<<< HEAD
    using System.ComponentModel.DataAnnotations;

    public partial class CacBoMon
    {
        public int MaCacBoMon { get; set; }

        [Required(ErrorMessage = "Ch?a nh??p th?ng tin")]
        public string TenCacBoMon { get; set; }

        [Required(ErrorMessage = "Ch?a nh??p th?ng tin")]
        public string NDTomTatCacBoMon { get; set; }

        [Required(ErrorMessage = "Ch?a nh??p th?ng tin")]
=======
    
    public partial class CacBoMon
    {
        public int MaCacBoMon { get; set; }
        public string TenCacBoMon { get; set; }
        public string NDTomTatCacBoMon { get; set; }
>>>>>>> Minhtam
        public string NDChiTietCacBoMon { get; set; }
    }
}
