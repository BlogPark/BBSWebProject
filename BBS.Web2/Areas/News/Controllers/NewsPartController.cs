using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.BLL;
using BBS.Model;
using BBS.Web2.Areas.News.Models;

namespace BBS.Web2.Areas.News.Controllers
{
    public class NewsPartController : Controller
    {
        //
        // GET: /News/NewsPart/

        private ArticleOperationBll bll = new ArticleOperationBll();
        private RightSideDataBLL rbll = new RightSideDataBLL();
        private SeoInfroBll sbll = new SeoInfroBll();
        /// <summary>
        /// 新闻首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            SeoInfoModel seoinfo = sbll.Getseoinfo("新闻首页");
            ViewBag.Title = seoinfo.PTitle;
            ViewBag.KeyWord = seoinfo.KeyWord;
            ViewBag.Description = seoinfo.PDescription;
            NewsIndexViewModel model = new NewsIndexViewModel();
            model.DevelopNewslist = bll.GetDevelopNewsForIndex();
            model.DomesticNewslist = bll.GetDomesticNewsForIndex();
            model.InternetNewslist = bll.GetInternetNewsForIndex();
            model.WorldNewslist = bll.GetWorldNewsForIndex();
            return View(model);
        }
        /// <summary>
        /// 新闻分类页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetListByCateid(int cid , int pindex = 1)
        {
            List<ArticleInfo> models = bll.GetNewsbyCateforPage(cid, pindex);
            if(models==null||models.Count<1)
              return  RedirectToAction("Error", "Home", new { area = "" });
            ViewBag.Title = "新闻列表";
            ViewBag.KeyWord = models[0].Tags;
            ViewBag.Description = models[0].DSummary;
            CatePageViewModel model = new CatePageViewModel();
            model.News = models;
            model.PageCurrent = pindex;
            model.PageSize = 8;
            model.TotalCount = models[0].Totalc;
            //model.TotalPage = models[0].Totalc % 8 > 0 ? models[0].Totalc / 8 + 1 : models[0].Totalc / 8;
            return View(model);
        }
        /// <summary>
        /// 新闻详情页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult NewsDetail(int id = 1)
        {
            ArticleInfo newinfo = bll.GetArticleinfoByID(id);
            if(newinfo==null)
              return  RedirectToAction("Error", "Home", new { area = "" });
            List<string> tags = new List<string>();
            if (!string.IsNullOrWhiteSpace(newinfo.Tags))
            {
                string[] ta = newinfo.Tags.Split(',');
                foreach (var item in ta)
                {
                    if (!tags.Contains(item))
                        tags.Add(item);
                }
            }
            ViewBag.Title = newinfo.TitleName;
            ViewBag.KeyWord = newinfo.Tags;
            ViewBag.Description = newinfo.DSummary;
            NewsDetailViewModel model = new NewsDetailViewModel();
            model.tags = tags;
            model.TitleName = newinfo.TitleName;
            model.PublishTime = newinfo.PublishTime.ToString("yyyy-MM-dd HH:mm:ss");
            model.MainPic = newinfo.MainPicURL;
            model.NewsContent = newinfo.Details.AContent;
            model.Author = newinfo.AuthorName;
            model.Comments = rbll.GetNewsCommentByNewsid(id);
            return View(model);
        }
        /// <summary>
        /// 得到右侧数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ReightPart()
        {
            Dictionary<int, List<ArticleInfo>> clickdata = rbll.GetRankingData();
            ReightDataViewModel model = new ReightDataViewModel();
            model.threedayData = clickdata[3];
            model.sevendayData = clickdata[7];
            model.thirtydayData = clickdata[30];
            model.Newcomment = rbll.GetNewCommentforright();
            model.Lastpublish = rbll.GetLastPublish();
            return PartialView("_ReightPartView", model);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
