﻿using System;
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
        public ActionResult Index(int pageindex=1)
        {
            DiscuessIndexViewModel model = new DiscuessIndexViewModel();
            model.dislist = dbll.GetDiscuessesForIndex(pageindex,PageSize);
            model.toplist = dbll.GetTopDiscuess();
            model.PageCurrent = pageindex;
            model.TotalCount = 100;
            model.PageSize = PageSize;
            return View(model);
        }
        /// <summary>
        /// 讨论详细页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DiscuessDetail(int id,int pindex=1)
        {
            DiscussDetailViewModel model = new DiscussDetailViewModel();
            model.Info = dbll.GetDiscuessByID(id);
            model.Comments = dbll.GetDiscussCommentByID(id);
            model.MemberInfo = mbll.GetMemberInfoByID(model.Info.PUserID);
            return View(model);
        }

        public ActionResult PartialData()
        {
            PartialViewModel model = new PartialViewModel();
            model.TopLickDiscuss = dbll.GetTopDiscuess();
            return PartialView("_RunderPartial", model);
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}