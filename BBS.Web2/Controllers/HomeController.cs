using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS.BLL;
using BBS.Model;
using BBS.Web2.Models;

namespace BBS.Web2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private ArticleOperationBll nbll = new ArticleOperationBll();
        private RightSideDataBLL rbll = new RightSideDataBLL();
        private MemberOperaterBll mbll = new MemberOperaterBll();
        private SeoInfroBll sbll = new SeoInfroBll();
        private HomeOperateBll hbll = new HomeOperateBll();
        public ActionResult Index()
        {
            SeoInfoModel seoinfo = sbll.Getseoinfo("网站首页");
            ViewBag.Title = seoinfo.PTitle;
            ViewBag.KeyWord = seoinfo.KeyWord;
            ViewBag.Description = seoinfo.PDescription;
            HomePageViewModel model = new HomePageViewModel();
            model.News = nbll.GetFristPageArticles().Take(48).ToList<ArticleInfo>();
            model.MemberStar = mbll.GetRecommendMember();
            model.DiscussInfo = "";
            return View(model);
        }
        /// <summary>
        /// 关于我们页面
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            AboutPageViewModel model = new AboutPageViewModel();
            return View(model);
        }
        /// <summary>
        /// 提交留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[UserAuthorize]        
        public ActionResult SubmitSugertion(AboutPageViewModel model)
        {
            MemberInfo info = (MemberInfo)Session["member"];
            if (info == null)
            {                
                return Json("2");
            }
            SuggestionInfo smodel = new SuggestionInfo();
            smodel.SUserID = info.MID;
            smodel.SUserName = info.Name;
            smodel.STitle = model.Title.Trim();
            smodel.SContent = model.Content.Trim();
            int result = hbll.InsertSuggest(smodel);
            if (result > 0)
            {
                return Json("1");
            }
            else
                return Json("错误");
        }

        /// <summary>
        /// 网站留言页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Content()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        /// <summary>
        /// 登录panel
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(string souceurl = "")
        {
            LoginViewModel model = new LoginViewModel();
            model.resutnurl = souceurl;
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string souceurl = "")
        {
            if (model.Name == null || model.Password == null)
            {
                model.Name = "";
                model.Password = "";
                ModelState.AddModelError("Password", "用户名或密码为空");
                return View(model);
            }
            if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Password))
            {
                ModelState.AddModelError("Password", "用户名或密码为空");
                return View(model);
            }
            MemberInfo member = new MemberInfo();
            member.Name = model.Name;
            member.Password = model.Password;
            MemberInfo info = mbll.GetMemberInfo(member);
            if (info == null)
            {
                ModelState.AddModelError("Password", "用户名或密码错误");
                return View(model);
            }
            else
            {
                //设置session和cookie
                Session["member"] = info;
                if (Request.Cookies["visitorid"] != null)
                {
                    HttpCookie _cookie = Request.Cookies["visitorid"];
                    _cookie.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(_cookie);
                }
                else
                {
                    HttpCookie aCookie = new HttpCookie("visitorid");
                    aCookie.Value = info.MID.ToString() + "," + info.Name.ToString();
                    aCookie.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(aCookie);
                }
            }
            if (!string.IsNullOrWhiteSpace(souceurl))
            {
                return Redirect(souceurl);
            }
            else if (!string.IsNullOrWhiteSpace(model.resutnurl))
            {
                return Redirect(model.resutnurl);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
        /// <summary>
        /// 快速注册会员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="souceurl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RegisterMember(LoginViewModel model)
        {
            if (model.email == null || model.Password == null || model.Name == null)
            {
                return Json("注册信息不完整");
            }
            if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Password) || string.IsNullOrWhiteSpace(model.email))
            {
                return Json("注册信息不完整");
            }
            MemberInfo ifo = mbll.GetMemberInfo(model.Name, model.email);
            if (ifo != null)
            {
                return Json("该注册账户已存在");
            }
            MemberInfo minfo = new MemberInfo();
            minfo.Name = model.Name.Trim();
            minfo.Password = model.Password;
            minfo.Email = model.email.Trim();
            MemberInfo info = mbll.FastRegisterMember(minfo);
            if (info == null)
            {
                ModelState.AddModelError("Password", "用户名或密码错误");
                return RedirectToAction("Login", "Home", model);
            }
            else
            {
                //设置session和cookie
                Session["member"] = info;
                if (Request.Cookies["visitorid"] != null)
                {
                    HttpCookie _cookie = Request.Cookies["visitorid"];
                    _cookie.Value = info.MID.ToString();
                    _cookie.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(_cookie);
                }
                else
                {
                    HttpCookie aCookie = new HttpCookie("visitorid");
                    aCookie.Value = info.MID.ToString() + "," + info.Name.ToString();
                    aCookie.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(aCookie);
                }
            }
            return Json("1");
        }
        /// <summary>
        /// 头部栏
        /// </summary>
        /// <returns></returns>
        public ActionResult Top()
        {
            TopPartModel model = new TopPartModel();
            MemberInfo info = (MemberInfo)Session["member"];
            if (info == null)
                model.IsHaveUser = false;
            else
            {
                model.IsHaveUser = true;
                model.UserID = info.MID;
                model.UserName = info.Name;
            }
            return PartialView("_Top",model);
        }
        /// <summary>
        /// 错误处理页
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
