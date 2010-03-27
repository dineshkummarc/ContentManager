using System.Web.Mvc;

namespace ContentNamespace.Web.Areas.Screen
{
    public class ScreenAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Screen";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Screen_default",
                "Screen.mvc/{controller}/{action}/{id}",
                new { action = "Index", id = "" }
            );
        }
    }
}
