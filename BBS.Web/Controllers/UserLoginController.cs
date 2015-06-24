using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.Web.Controllers
{
    public class UserLoginController : Controller
    {
        //
        // GET: /UserLogin/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Registration()
        {
            return View();
        }
    }
}
