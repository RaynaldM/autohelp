using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AutoHelp.Helpers;

namespace AutoHelp.Controllers
{
    [ADAuthorize]
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
                    var fileName = pathToSave + file.FileName.Substring(file.FileName.LastIndexOf(@"\", StringComparison.Ordinal));
                    file.SaveAs(fileName);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}