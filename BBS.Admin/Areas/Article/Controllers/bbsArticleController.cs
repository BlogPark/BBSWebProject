using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.Admin.Areas.Article.Models;

namespace BBS.Admin.Areas.Article.Controllers
{
    public class bbsArticleController : Controller
    {
        //
        // GET: /Article/bbsArticle/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ArticleInfoModel model = new ArticleInfoModel();
            return View(model);
        }

        public ActionResult Update() 
        {
            return View();
        }
    }
}
