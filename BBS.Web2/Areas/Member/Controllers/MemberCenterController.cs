using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.Model;
using BBS.Web2.Areas.Member.Models;
using BBS.BLL;

namespace BBS.Web2.Areas.Member.Controllers
{
     [UserAuthorize]
    public class MemberCenterController : Controller
    {
        //
        // GET: /Member/MemberCenter/       
         private BlogContentBll bbll = new BlogContentBll();
         private DiscuessBll dbll = new DiscuessBll();
         /// <summary>
         /// 首页
         /// </summary>
         /// <returns></returns>
        public ActionResult Index()
        {
            MembermsgViewModel model = new MembermsgViewModel();
            model.member = (MemberInfo)Session["member"];
            model.Blogs = bbll.GetBlogsByMemberid(model.member.MID);
            model.Discusses = dbll.GetDiscussByMemberid(model.member.MID);
            return View(model);
        }
         /// <summary>
         ///左侧视图
         /// </summary>
         /// <returns></returns>
        public ActionResult Leftside()
        {
            LeftsidePartModel model = new LeftsidePartModel();
            model.member = (MemberInfo)Session["member"];
            return PartialView("_memleftpartial",model);
        }
         /// <summary>
         /// 发表博文页
         /// </summary>
         /// <returns></returns>
        public ActionResult PublishBlog()
        {
            return View();
        }
         [HttpPost]
        public ActionResult PublishBlog(MembermsgViewModel model)
        {
            return View();
        }
         /// <summary>
         /// 发表话题页
         /// </summary>
         /// <returns></returns>
         public ActionResult PublishDiscuss()
         {
             return View();
         }
         [HttpPost]
         public ActionResult PublishDiscuss(string title,string content)
         {
             return Json(title);
         }

        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
