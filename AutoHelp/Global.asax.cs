using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoHelp.domain.Models;
using AutoHelp.Helpers;

namespace AutoHelp
{
    public class MvcApplication : HttpApplication
    {
        public static List<Assembly> Assemblies { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var docSvr = DocServiceFactory.CreatServices();
            Assemblies = docSvr.SetAssemblies();
        }
    }
}
