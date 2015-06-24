using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBS.Admin.Areas.Advertisement.Controllers
{
    public class advmanagerController : Controller
    {
        //
        // GET: /Advertisement/advmanager/
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加广告位置
        /// </summary>
        /// <returns></returns>
        public ActionResult Addadvposition()
        {
            return View();
        }
        /// <summary>
        /// 发布新广告
        /// </summary>
        /// <returns></returns>
        public ActionResult publishnewadv()
        {
            return View();
        }
        /// <summary>
        /// 编辑广告
        /// </summary>
        /// <returns></returns>
        public ActionResult editadv()
        {
            return View();
        }

        public ActionResult ScheduleManager()
        {
            return View();
        }
    }
}
