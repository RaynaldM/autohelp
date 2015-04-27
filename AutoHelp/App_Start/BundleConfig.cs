using System.Web.Optimization;

namespace AutoHelp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;   //enable CDN support

            //add link to jquery on the CDN
            const string jqueryCdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.0.min.js";

            bundles.Add(new ScriptBundle("~/bundles/jquery",
                        jqueryCdnPath).Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/manage")
                        .Include("~/Scripts/jquery.form.js")
                        .Include("~/Scripts/bootstrap-filestyle.js")
                        .Include("~/Scripts/ts/ManageIndex.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                      .Include("~/Scripts/modernizr-*")
                      .Include("~/Scripts/fixIe10mobil.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/moment-with-langs.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/handlebars.js",
                      "~/Scripts/jquery-sortable.js",
                      "~/Scripts/stringExt.js",
                      "~/Scripts/ts/base.js",
                      "~/Scripts/ts/helpers.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/app.css"));
        }
    }
}
