using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoHelp.domain.Models;
using AutoHelp.domain.Services;

namespace AutoHelp.Controllers
{
    public class FilesController : ApiController
    {
        public IEnumerable<Assembly> Get()
        {
            return MvcApplication.Assemblies.Select(assembly => new Assembly
            {
                Id = assembly.Id,
                Name = assembly.Name,
                FullName = assembly.FullName,
                Namespaces = null
            }).ToArray();
        }

        public bool Get(Guid id, Boolean deleted)
        {
            var assembly = MvcApplication.Assemblies.SingleOrDefault(a => a.Id == id);

            var docSrv = new DocServices();
            if (assembly != null && docSrv.DeletePhysicalFile(assembly.FileName))
            {
                MvcApplication.Assemblies.Remove(assembly);
                return true;
            }
            return false;
        }

        //[HttpDelete]
        //public void Delete(Guid id)
        //{
        //    if (id == Guid.Empty)
        //    {

        //    }
        //}
    }
}