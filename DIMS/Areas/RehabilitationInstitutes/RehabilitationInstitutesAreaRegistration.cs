using System.Web.Mvc;

namespace DIMS.Areas.RehabilitationInstitutes
{
    public class RehabilitationInstitutesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RehabilitationInstitutes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RehabilitationInstitutes_default",
                "RehabilitationInstitutes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}