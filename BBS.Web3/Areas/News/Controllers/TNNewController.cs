using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.Web3.Areas.News.Controllers
{
    public class TNNewController : Controller
    {
        //
        // GET: /News/TNNew/

        /// <summary>
        /// 新闻列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewsDetail()
        {
            return View();
        }

    }
}
