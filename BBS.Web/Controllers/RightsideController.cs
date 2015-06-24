using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.BLL;
using BBS.Web.Models;

namespace BBS.Web.Controllers
{
    public class RightsideController : Controller
    {
        //右侧广告  分部试图
        // GET: /Rightside/

        private RightSideDataBLL rbll = new RightSideDataBLL();
        public ActionResult Index()
        {
            ReightParticalViewModel model = new ReightParticalViewModel();
            model.GetLikeArticle = rbll.GetUserLikeComment();//猜你喜欢
            model.NewComment = rbll.GetNewComment();//最新评论
            model.TopComment = rbll.GetTopComment();//大家都在说            
            model.AdvList = rbll.GetPageindexAdv();//广告列表
            model.FriendLinks = rbll.GetFriendLink();//友情链接
            return PartialView("_RightAdvPartial", model);
        }

    }
}
