using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.Admin.Areas.Member.Controllers
{
    public class MembersController : Controller
    {
        //
        // GET: /Member/Members/

        public ActionResult Index()
        {
            return View();
        }

    }
}
