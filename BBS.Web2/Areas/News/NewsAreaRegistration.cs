using System.Web.Mvc;

namespace BBS.Web2.Areas.News
{
    public class NewsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "News";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "News_index",
                "News.html",
                new { controller = "NewsPart", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "News_detail",
                "News/n_{id}.html",
                new { controller = "NewsPart", action = "NewsDetail", id = UrlParameter.Optional }
            );
            context.MapRoute(
               "News_cate_pqq",
               "News/c{cid}_{pindex}.html",
               new { controller = "NewsPart", action = "GetListByCateid", cid = 1, pindex = 1, id = UrlParameter.Optional }
           );
            context.MapRoute(
                "News_cate",
                "News/c{cid}.html",
                new { controller = "NewsPart", action = "GetListByCateid", cid = 1, id = UrlParameter.Optional }
            );           
            context.MapRoute(
                "News_default",
                "News/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
