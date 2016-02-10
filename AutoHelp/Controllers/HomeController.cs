using System;
using System.Web.Mvc;

namespace AutoHelp.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize(Roles = @"VPs")]
        public ActionResult Index()
        {
            ViewBag.VirtualUrl = this.VirtualUrl();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public String VirtualUrl()
        {
            return string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
        }
    }
}