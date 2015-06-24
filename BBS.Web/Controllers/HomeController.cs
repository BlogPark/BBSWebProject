using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.BLL;
using BBS.Model;
using BBS.Web.Models;

namespace BBS.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private ArticleOperationBll abll = new ArticleOperationBll();//文章操作BLL
        private HomeOperateBll hbll = new HomeOperateBll();//首页数据BLL
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "开发资讯网";
            ViewBag.KeyWord = "开发,编程,IT,资讯,C#,.NET,JAVA,PHP,技术";
            ViewBag.Description = "开发新闻网致力于为广大的程序猿同志们提供最新鲜的资讯和技术解决方案，为讨论技术和了解最新编程动态搭建一个美好的平台";
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.ArticleInfolist = abll.GetFristPageArticles();//文章列表
            model.RecommendArticlelist = abll.GetRecommonArticles();//得到置顶文章
            model.TopArticlelist = abll.GetShowTopArticles();
            return View(model);
        }

        /// <summary>
        /// 分类页面
        /// </summary>
        /// <param name="cateid"></param>
        /// <returns></returns>
        public ActionResult CategoryPage(int cateid)
        {
          
            ViewBag.Description = "开发新闻网致力于为广大的程序猿同志们提供最新鲜的资讯和技术解决方案，为讨论技术和了解最新编程动态搭建一个美好的平台";
            CategoryType cmodel = hbll.GetCategoryData(cateid);
            if (cmodel == null)
                return RedirectToAction("Index", "Home");
            CategoryViewModel model = new CategoryViewModel();
            model.CategoryID = cmodel.ID;
            model.Articles = cmodel.Articles;
            model.CategoryName = cmodel.CategoryName;
            model.iconname = cmodel.Iconname;  
            ViewBag.Title = cmodel.CategoryName+"-开发资讯网";
            ViewBag.KeyWord =cmodel.CategoryName+ ",开发,编程,IT,资讯,C#,.NET,JAVA,PHP,技术";
            return View(model);
        }
    }
}
