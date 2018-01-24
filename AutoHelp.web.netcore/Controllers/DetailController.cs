using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutoHelp.web.netcore.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index(Guid id)
        {
           ViewData["id"] = id;
            return View();
        }
    }
}