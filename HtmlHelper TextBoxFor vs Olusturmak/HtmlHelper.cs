using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Aspnet_Mvc_Custom_Helper_olusturmak.Models
{
    public static class HtmlHelper
    {
        public static MvcHtmlString MyTextBox<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,Expression<Func<TModel,TValue>> expression)
        {
            var div = new TagBuilder("div");

            var lbl = htmlHelper.LabelFor(expression);
            var txt = htmlHelper.TextBoxFor(expression);
            var err = htmlHelper.ValidationMessageFor(expression);
            div.InnerHtml += lbl;
            div.InnerHtml += txt;
            div.InnerHtml += err;
            return new MvcHtmlString( div.ToString());
        }
        public static MvcHtmlString MyPassword<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            var div = new TagBuilder("div");

            var lbl = htmlHelper.LabelFor(expression);
            var txt = htmlHelper.PasswordFor(expression);
            var err = htmlHelper.ValidationMessageFor(expression);
            div.InnerHtml += lbl;
            div.InnerHtml += txt;
            div.InnerHtml += err;
            return new MvcHtmlString(div.ToString());
        }

      
    }
}