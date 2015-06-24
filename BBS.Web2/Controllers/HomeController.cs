using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.BLL;
using BBS.Model;
using BBS.Web2.Models;

namespace BBS.Web2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private ArticleOperationBll nbll = new ArticleOperationBll();
        private RightSideDataBLL rbll = new RightSideDataBLL();
        private MemberOperaterBll mbll = new MemberOperaterBll();
        private SeoInfroBll sbll = new SeoInfroBll();
        public ActionResult Index()
        {
            SeoInfoModel seoinfo = sbll.Getseoinfo("网站首页");
            ViewBag.Title = seoinfo.PTitle;
            ViewBag.KeyWord = seoinfo.KeyWord;
            ViewBag.Description = seoinfo.PDescription;
            HomePageViewModel model = new HomePageViewModel();
            model.News = nbll.GetFristPageArticles().Take(12).ToList<ArticleInfo>();
            model.MemberStar = mbll.GetRecommendMember();
            model.DiscussInfo = "";
            return View(model);
        }
        /// <summary>
        /// 关于我们页面
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }
        /// <summary>
        /// 网站留言页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Content()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
