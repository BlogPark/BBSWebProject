using System.Web.Mvc;

namespace BBS.Web2.Areas.BlogPark
{
    public class BlogParkAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BlogPark";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BlogPark_default",
                "BlogPark/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
