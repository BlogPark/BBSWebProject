using System.Web.Mvc;

namespace BBS.Web2.Areas.Discuss
{
    public class DiscussAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Discuss";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "Dis_index",
               "Discuess.html",
               new { controller = "DiscussPart", action = "Index", id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Dis_p_index",
               "Discuess_{pageindex}.html",
               new { controller = "DiscussPart", action = "Index", pageindex = 0, id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Dis_detail_p_index",
               "Dis/de{id}_{pindex}.html",
               new { controller = "DiscussPart", action = "DiscuessDetail", pindex = 0, id = UrlParameter.Optional }
           );
            context.MapRoute(
               "Dis_detail_index",
               "Dis/de{id}.html",
               new { controller = "DiscussPart", action = "DiscuessDetail", id = UrlParameter.Optional }
           );
            context.MapRoute(
                "Discuss_default",
                "Discuss/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
