using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.Admin.Controllers
{
    public class SystemsController : Controller
    {
        //
        // GET: /Systems/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult sysusermanager()
        {
            return View();
        }

    }
}
