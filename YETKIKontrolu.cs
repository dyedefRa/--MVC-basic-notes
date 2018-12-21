using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SiparisTakip.UI.App_Classes
{
    public class YETKIKontrolu:ActionFilterAttribute
    {
        public YETKIKontrolu()
        {
            //DIREK PARAMETRE VERMEDEN KULLANILSIN 
        }
        //YetkiKontrolune dinamik olarak arguman göndereceğiz.(Metodların üstünde Attribute olarak yazılan yerde) .. ve burada o argumanı yakalayacağız ve argumanına gore işlem yaptıracağız.
        public YETKIKontrolu(string attributedeVerilen)
        {
            this.modulAdi = attributedeVerilen;
        }


        private string modulAdi;

        //BU ILK MANTIGI //CTOR LARI VE PROPLARI KATMADAN DIREK OLARAK SADECE ALTTAKI KOD YETER
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (filterContext.HttpContext.Session["kullaniciId"]==null)
        //    {
        //        filterContext.HttpContext.Response.Redirect("/Kullanici/Login");
        //    }
        //    base.OnActionExecuting(filterContext);

        //}
        ////////////////////////////////////
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["kullaniciId"] == null)
            {

              string deger=  this.modulAdi;
                //    filterContext.HttpContext.Response.Redirect("/Kullanici/Login");
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Kullanici" }, { "action", "Login" } });
            }
            base.OnActionExecuting(filterContext);

        }

    }
}