using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.Admin.Areas.SysNotice.Controllers
{
    public class NoticeController : Controller
    {
        //
        // GET: /SysNotice/Notice/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewPublish()
        {
            return View();
        }

        public ActionResult EditNotice()
        {
            return View();
        }

    }
}
