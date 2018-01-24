using System;
using System.Collections.Generic;
using AutoHelp.web.netcore.Models;
using AutoHelp.web.netcore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoHelp.web.netcore.Controllers
{
    [Produces("application/json")]
    //[Route("api/Assembly")]
    public class AssemblyController : Controller
    {
        private readonly IDocServices _docServices;

        public AssemblyController(IDocServices docSrv)
        {
            this._docServices = docSrv;
        }

        [HttpGet]
        [Route("api/Assembly/list")]
        public IActionResult Get()
        {
            var assemblies = this._docServices.GetAssembliesList();
            return Json(assemblies);
        }

        [HttpPost]
        [Route("api/Assembly/{id}")]
        public IActionResult Post(Guid id)
        {
            var assembly = this._docServices.GetAssembly(id);
            return Json(assembly);
        }
    }
}