﻿using System;
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
        public ActionResult Index()
        {
            SeoInfoModel seoinfo = sbll.Getseoinfo("网站首页");
            ViewBag.Title = seoinfo.PTitle;
            ViewBag.KeyWord = seoinfo.KeyWord;
            ViewBag.Description = seoinfo.PDescription;
            HomePageViewModel model = new HomePageViewModel();
            model.News = nbll.GetFristPageArticles().Take(12).ToList<ArticleInfo>();
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
        [HttpPost]
        public ActionResult SubmitSugertion(AboutPageViewModel model)
        {

            return View();
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
        public ActionResult Login()
        {
            return View();
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
                    aCookie.Value = info.MID.ToString();
                    aCookie.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(aCookie);
                }
            }
            if (!string.IsNullOrWhiteSpace(souceurl))
            {
                return Redirect(souceurl);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
        [HttpPost]
        public ActionResult RegisterMember(LoginViewModel model,string souceurl="")
        {
            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}
