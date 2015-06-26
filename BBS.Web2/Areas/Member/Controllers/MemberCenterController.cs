using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.Model;
using BBS.Web2.Areas.Member.Models;

namespace BBS.Web2.Areas.Member.Controllers
{
     [UserAuthorize]
    public class MemberCenterController : Controller
    {
        //
        // GET: /Member/MemberCenter/       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Leftside()
        {
            LeftsidePartModel model = new LeftsidePartModel();
            model.member = (MemberInfo)Session["member"];
            return PartialView("_memleftpartial",model);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
