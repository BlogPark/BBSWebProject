using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.Web2.Areas.Member.Controllers
{
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
            return PartialView("_memleftpartial");
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
