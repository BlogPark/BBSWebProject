using System.Web.Mvc;

namespace BBS.Admin.Areas.SysNotice
{
    public class SysNoticeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SysNotice";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SysNotice_default",
                "SysNotice/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
