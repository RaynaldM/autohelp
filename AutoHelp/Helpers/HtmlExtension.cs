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

    }
}