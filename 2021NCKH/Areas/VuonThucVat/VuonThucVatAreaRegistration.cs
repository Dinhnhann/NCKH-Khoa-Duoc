using System.Web.Mvc;

namespace _2021NCKH.Areas.VuonThucVat
{
    public class VuonThucVatAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "VuonThucVat";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "VuonThucVat_default",
                "VuonThucVat/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}