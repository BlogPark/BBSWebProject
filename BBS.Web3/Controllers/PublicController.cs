using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.Web3.Controllers
{
    public class PublicController : Controller
    {
        //
        // GET: /Public/

        public ActionResult Header()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }

        public ActionResult Reagier()
        {
            return View();
        }
    }
}
