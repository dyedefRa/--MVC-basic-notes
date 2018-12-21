using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisTakip2.MvcUI.App_Fazlaliklar
{
    //:IActionFilter da olabilirdi.
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.Session["aktifKullaniciID"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Kullanici/KullaniciGiris");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}