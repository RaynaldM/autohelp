using System.Web.Optimization;

namespace AutoHelp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;   //enable CDN support

            //add link to jquery on the CDN
            const string jqueryCdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.1.min.js";

            bundles.Add(new ScriptBundle("~/bundles/jquery",
                        jqueryCdnPath).Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/manage")
                        .Include("~/Scripts/jquery.form.js")
                        .Include("~/Scripts/bootstrap-filestyle.js")
                        .Include("~/TypeScripts/ManageIndex.js"));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr")
            //          .Include("~/Scripts/modernizr-*")
            //          .Include("~/Scripts/fixIe10mobil.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment-with-locales.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/handlebars.js",
                      "~/Scripts/jquery-sortable.js",
                      "~/Scripts/stringExt.js")
                      .Include("~/TypeScripts/Base/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/app.css"));
        }
    }
}
