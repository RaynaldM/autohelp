﻿using System;
using System.Web.Mvc;

namespace AutoHelp.Controllers
{
    public class HomeController : Controller
    {
         public ActionResult Index()
        {
            ViewBag.VirtualUrl = this.VirtualUrl();
            return View();
        }

        public String VirtualUrl()
        {
            return string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
        }
    }
}