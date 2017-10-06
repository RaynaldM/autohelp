using System;
using System.Web.Configuration;
using System.Web.Hosting;
using AutoHelp.domain.Services;

namespace AutoHelp.Helpers
{
    public static class DocServiceFactory
    {
        public static DocServices CreatServices()
        {
            // get value from web config
            var assemblyPath = WebConfigurationManager.AppSettings.Get("AssemblyDirectory");
            assemblyPath = HostingEnvironment.MapPath(String.IsNullOrWhiteSpace(assemblyPath) ? "~/App_Data" : assemblyPath);
            return new DocServices(assemblyPath);
        }
    }
}
