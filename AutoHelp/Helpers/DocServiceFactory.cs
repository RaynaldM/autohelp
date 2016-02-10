using System;
using System.Web.Configuration;
using System.Web.Hosting;
using AutoHelp.domain.Services;

namespace AutoHelp.Helpers
{
    static public class DocServiceFactory
    {
        static public DocServices CreatServices()
        {
            // get value from web config
            var assemblyPath = WebConfigurationManager.AppSettings.Get("AssemblyDirectory");
            if (String.IsNullOrWhiteSpace(assemblyPath))
            {
                // if it's not define take the App_Data path
                assemblyPath = HostingEnvironment.MapPath("~/App_Data");

            }
            else
            {
                assemblyPath = HostingEnvironment.MapPath(assemblyPath);
            }
            return new DocServices(assemblyPath);
        }
    }
}
