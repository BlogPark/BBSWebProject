using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.Model;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public class UserAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            MemberInfo user = (MemberInfo)filterContext.HttpContext.Session["member"];
            if (user == null)// || filterContext.HttpContext.Session.Mode != 0)
            {
                string s = filterContext.RequestContext.HttpContext.Request.Url.ToString();
                //filterContext.Result = new RedirectResult("/Admin/SysUser/Login");
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "Home" },{"area",""}, { "souceurl", s } });
            }
            return;
        }
    }
}
