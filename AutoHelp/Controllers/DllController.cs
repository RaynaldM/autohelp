using System;
using System.Linq;
using System.Web.Mvc;

namespace AutoHelp.Controllers
{
    public class DllController : Controller
    {
        // GET: Dll
        public ActionResult Index(Guid id)
        {
            //var docSvr = new DocServices();
            //MvcApplication.Assemblies = docSvr.SetAssemblies();
            var data = MvcApplication.Assemblies.SingleOrDefault(p => p.Id == id);
            return View(data);
        }
    }
}