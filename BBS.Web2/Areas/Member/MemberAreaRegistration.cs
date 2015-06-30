using System.Web.Mvc;

namespace BBS.Web2.Areas.Member
{
    public class MemberAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Member";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "member_index",
               "User.html",
               new { controller = "MemberCenter", action = "Index", id = UrlParameter.Optional }
           );
            context.MapRoute(
                "Member_default",
                "Member/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
