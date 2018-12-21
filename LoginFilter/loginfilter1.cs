  public class LoginFilter : FilterAttribute, IActionFilter
    {
        //ActionMetod çalıştırıldıktan sonra devreye girer.
        // Home/Index e verdik ..
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            var sessionControl =(Kullanici) filterContext.HttpContext.Session["AktifKullanici"];
            if (sessionControl==null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });

            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
         
        }
    }