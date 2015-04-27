using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AutoHelp.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString TypeLink(this HtmlHelper helper, string fullname)
        {
            if (fullname.IndexOf(".", StringComparison.Ordinal) == -1)
            {
                fullname = "System." + fullname;
            }

            // Change this to checking if the namespace is in the Application.Namespaces
            if (fullname.StartsWith("System.") || fullname.StartsWith("Microsoft."))
            {
                var query = fullname;

                // Replace types with a T
                if (fullname.IndexOf("<", StringComparison.Ordinal) != -1)
                {
                    // This only matches one generic argument, however that still works with IDictionary<TKey,TValue> + google
                    var regex = new Regex(@"(.*)\<([a-zA-Z0-9\.]*)\>");
                    query = regex.Replace(fullname, "$1<T>");
                }

                return MvcHtmlString.Create("<a href=\"http://www.google.com/search?q=" + query + "&btnI=Im+Feeling+Lucky\">" + helper.Encode(fullname) + "</a>");
            }
            return helper.ActionLink(fullname, "Type", new { id = fullname });
        }

        public static String RootUrl(this UrlHelper instance)
        {
            String sRet = string.Empty;
            var url = instance.RequestContext.HttpContext.Request.Url;
            if (url != null)
            {
                sRet += url.Scheme + "://";
                sRet += url.Host;
                sRet += ":" + url.Port;
            }
            return sRet;
        }

        public static MvcHtmlString CompressedPartial(this HtmlHelper htmlHelper, string partialViewName)
        {
            return CompressedPartial(htmlHelper, partialViewName, null /* model */, htmlHelper.ViewData);
        }

        public static MvcHtmlString CompressedPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData)
        {
            return CompressedPartial(htmlHelper, partialViewName, null /* model */, viewData);
        }

        public static MvcHtmlString CompressedPartial(this HtmlHelper htmlHelper, string partialViewName, object model)
        {
            return CompressedPartial(htmlHelper, partialViewName, model, htmlHelper.ViewData);
        }

        public static MvcHtmlString CompressedPartial(this HtmlHelper htmlHelper, string partialViewName, object model, ViewDataDictionary viewData)
        {
            var result = htmlHelper.RenderPartialInternal(partialViewName, viewData, model, ViewEngines.Engines);
            return MvcHtmlString.Create(result);
        }

        private static string RenderPartialInternal(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, object model, ViewEngineCollection viewEngineCollection)
        {
            if (String.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException(@"Empty view", "partialViewName");
            }

            ViewDataDictionary newViewData = model == null
                ? (viewData == null ? new ViewDataDictionary(htmlHelper.ViewData) : new ViewDataDictionary(viewData))
                : (viewData == null ? new ViewDataDictionary(model) : new ViewDataDictionary(viewData) { Model = model });

            using (var writer = new StringWriter(CultureInfo.CurrentCulture))
            {
                var newViewContext = new ViewContext(htmlHelper.ViewContext, htmlHelper.ViewContext.View, newViewData, htmlHelper.ViewContext.TempData, writer);

                IView view = viewEngineCollection.FindPartialView(newViewContext, partialViewName).View;

                view.Render(newViewContext, writer);
                return SimpleHtmlMinifier(writer.ToString());
            }
        }

        private static String SimpleHtmlMinifier(String html)
        {
            html = Regex.Replace(html, @"(?<=[^])\t{2,}|(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,11}(?=[<])|(?=[\n])\s{2,}", "");
            html = Regex.Replace(html, @"[ \f\r\t\v]?([\n\xFE\xFF/{}[\];,<>*%&|^!~?:=])[\f\r\t\v]?", "$1");
            html = html.Replace(";\n", ";");
            return html;
        }
    }
}