using System.Web.Mvc;

namespace MvcApplication1.Areas.Escuela1
{
    public class Escuela1AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Escuela1";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Escuela1_default",
                "Escuela1/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
