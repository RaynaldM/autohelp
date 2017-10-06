using aspnet_mvc_helpers;
using AutoHelp.Helpers;
using Elmah;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AutoHelp.Controllers
{
    //[ADAuthorize] // Uncomment this if you want to limit access to a specific group in AD (this group is setted in web.config)
    public class ManageController : Controller
    {
        // GET: Config
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, NoCache]
        public JsonResult ResetAssemblies()
        {
            var srv = DocServiceFactory.CreatServices();
            MvcApplication.Assemblies = srv.SetAssemblies();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AssemblyAdd(IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                var srv = DocServiceFactory.CreatServices();
                var pathToSave = srv.DataPath;
                foreach (var file in files)
                {
                    string filename = file.FileName;
                    int lastSlash = filename.LastIndexOf("\\", StringComparison.Ordinal);
                    string trailingPath = filename.Substring(lastSlash + 1);
                    string fullPath = pathToSave + "\\" + trailingPath;
                 
                    file.SaveAs(fullPath);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}