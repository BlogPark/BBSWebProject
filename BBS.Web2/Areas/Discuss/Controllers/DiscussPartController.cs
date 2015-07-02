using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.Model;
using BBS.BLL;
using BBS.Web2.Areas.Discuss.Models;

namespace BBS.Web2.Areas.Discuss.Controllers
{
    public class DiscussPartController : Controller
    {
        //
        // GET: /Discuss/DiscussPart/
        private DiscuessBll dbll = new DiscuessBll();
        MemberOperaterBll mbll = new MemberOperaterBll();
        public readonly int PageSize = 30;
        /// <summary>
        /// 讨论首页
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public ActionResult Index(int pageindex = 1)
        {
            DiscuessIndexViewModel model = new DiscuessIndexViewModel();
            model.toplist = dbll.GetTopDiscuess();
            model.dislist = dbll.GetDiscuessesForIndex(pageindex, PageSize);
            int total = 0;
            if (model.dislist.Count > 0)
            {
                total = model.toplist.Count + model.dislist[0].rowco;
            }
            else
            {
                total = model.toplist.Count;
            }
            model.PageCurrent = pageindex;
            model.TotalCount = total;
            model.PageSize = PageSize;
            return View(model);
        }
        /// <summary>
        /// 讨论详细页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DiscuessDetail(int id, int pindex = 1)
        {
            DiscussDetailViewModel model = new DiscussDetailViewModel();
            model.Info = dbll.GetDiscuessByID(id);
            model.Comments = dbll.GetDiscussCommentByID(id, pindex, PageSize);
            model.MemberInfo = mbll.GetMemberInfoByID(model.Info.PUserID);
            model.PageCurrent = pindex;
            model.TotalCount = model.Comments.Count > 0 ? model.Comments[0].rowco : 0;
            model.PageSize = PageSize;
            return View(model);
        }

        public ActionResult PartialData()
        {
            PartialViewModel model = new PartialViewModel();
            model.TopLickDiscuss = dbll.GetTopDiscuess();
            return PartialView("_RunderPartial", model);
        }
        [HttpPost]
        public ActionResult Addsupport(int id = 0)
        {
            if (id == 0)
            {
                return Json("0");
            }
            int rowcount = dbll.UpdateCommentSupput(id);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public ActionResult AddAgainst(int id = 0)
        {
            if (id == 0)
            {
                return Json("0");
            }
            int rowcount = dbll.UpdateCommentAgainstCount(id);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }
        [HttpPost]
        public ActionResult AddClick(int id = 0)
        {
            if (id == 0)
            {
                return Json("0");
            }
            int rowcount = dbll.UpdateDiscussClickCount(id);
            if (rowcount > 0)
            {
                return Json("1");
            }
            else
            {
                return Json("0");
            }
        }

        [HttpPost]
        public ActionResult AddComment(string content, int did)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return Json("0");
            }
            MemberInfo info = (MemberInfo)Session["member"];
            if (info == null)
            {
                return Json("-2");
            }
            DiscussComment model = new DiscussComment();
            model.UserID = info.MID;
            model.UserName = info.Name;
            model.CContent = content;
            model.Did = did;
            int result = dbll.AddDiscussComment(model);
            if (result > 0)
            {
                return Json("1");
            }
            else
                return Json("0");
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
