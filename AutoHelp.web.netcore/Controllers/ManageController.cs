using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoHelp.web.netcore.Services;
using AutoHelp.web.netcore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoHelp.web.netcore.Controllers
{
    public class ManageController : Controller
    {
        private readonly IDocServices _docServices;

        public ManageController(IDocServices docSrv)
        {
            this._docServices = docSrv;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(List<IFormFile> file)
        {
            return Json(true);
        }

        //[HttpGet]
        //public JsonResult ResetAssemblies()
        //{
        //    var srv = DocServiceFactory.CreatServices();
        //    MvcApplication.Assemblies = srv.SetAssemblies();
        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult AssemblyAdd(IEnumerable<HttpPostedFileBase> files)
        //{
        //    try
        //    {
        //        var srv = DocServiceFactory.CreatServices();
        //        var pathToSave = srv.DataPath;
        //        foreach (var file in files)
        //        {
        //            string filename = file.FileName;
        //            int lastSlash = filename.LastIndexOf("\\", StringComparison.Ordinal);
        //            string trailingPath = filename.Substring(lastSlash + 1);
        //            string fullPath = pathToSave + "\\" + trailingPath;

        //            file.SaveAs(fullPath);
        //        }
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorSignal.FromCurrentContext().Raise(ex);
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
