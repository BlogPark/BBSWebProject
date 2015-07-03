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
            return PartialView("_memleftpartial", model);
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
        public ActionResult PublishDiscuss(string title, string content)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                return Json("请完善标题或内容");
            }
            MemberInfo member = (MemberInfo)Session["member"];
            if (member == null)
            {
                return Json("-2");
            }
            DiscussInfo model = new DiscussInfo();
            model.Title = title;
            model.Dcontent = content;
            model.PUserID = member.MID;
            model.PUserName = member.Name;
            int rowcount = dbll.AddDiscuss(model);
            if (rowcount > 0)
                return Json("1");
            else
                return Json("0");
        }
        /// <summary>
        /// 修改会员信息页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EditMemberInfo()
        {
            MemberInfo member = (MemberInfo)Session["member"];
            MemberInfoViewModel viewmodel = new MemberInfoViewModel();
            viewmodel.BirthDay = Convert.ToDateTime(member.Birthday).ToString("yyyy-MM-dd");
            viewmodel.Discription = member.Description;
            viewmodel.HeadPic = member.HeadPic;
            viewmodel.Likes = member.Likes;
            viewmodel.Name = member.Name;
            viewmodel.Sex = member.Sex;
            viewmodel.Tag = member.Tags;
            return View();
        }
        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateMemberPic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PreviewImage()
        {
            var bytes = new byte[0];
            ViewBag.Mime = "image/png";

            if (Request.Files.Count == 1)
            {
                bytes = new byte[Request.Files[0].ContentLength];
                Request.Files[0].InputStream.Read(bytes, 0, bytes.Length);
                ViewBag.Mime = Request.Files[0].ContentType;
            }

            ViewBag.Message = Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks);
            return PartialView();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
