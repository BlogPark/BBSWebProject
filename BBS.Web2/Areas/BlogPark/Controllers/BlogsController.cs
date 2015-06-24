using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.BLL;
using BBS.Model;
using BBS.Web2.Areas.BlogPark.Models;


namespace BBS.Web2.Areas.BlogPark.Controllers
{
    public class BlogsController : Controller
    {
        //
        // GET: /BlogPark/Blogs/
        private BlogContentBll bll = new BlogContentBll();
        /// <summary>
        /// 博客首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<MemberInfo> blogs = bll.GetBlogMembers();
            BlogIndexViewModel model = new BlogIndexViewModel();
            model.BlogMembers = blogs;
            return View(model);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
