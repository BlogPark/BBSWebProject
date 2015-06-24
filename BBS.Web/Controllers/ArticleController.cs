using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.Model;
using BBS.Web.Models;
using BBS.BLL;

namespace BBS.Web.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        private ArticleOperationBll abll = new ArticleOperationBll();
        /// <summary>
        /// 文章页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            ArticleDetailViewModel model = new ArticleDetailViewModel();
            ArticleInfo article = abll.GetArticleinfoByID(id);
            if (article == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.ACountent = article.Details.AContent.Replace(@"http://www.kaifanews.com", @"http://qxw1152050031.my3w.com").Replace(@"http://images.cnitblog.com","");
                model.ClickCount = article.ClickCount;
                model.AuthorName = article.AuthorName;
                model.CategoryName = article.CategoryName;
                model.PublishTime = article.PublishTime;
                model.SourceUrl = article.SourceUrl;
                model.TitleName = article.TitleName;
            }
            ViewBag.Title =article.TitleName;
            ViewBag.KeyWord ="开发,编程,IT,资讯,C#,.NET,JAVA,PHP,技术,"+article.Tags;
            ViewBag.Description = article.DSummary;
            return View(model);
        }

    }
}
