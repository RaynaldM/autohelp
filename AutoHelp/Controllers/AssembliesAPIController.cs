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

        // DELETE api/<controller>/5
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

    public class AssembliesController : ApiController
    {
        /// <summary>
        /// Gets some very important data from the server.
        /// </summary>
        public IEnumerable<Assembly> Get()
        {
            return MvcApplication.Assemblies;
        }

        /// <summary>
        /// Looks up some data by ID.
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        public Namespace[] Get(Guid id)
        {
            var ass = MvcApplication.Assemblies.FirstOrDefault(p => p.Id == id);
            if (ass != null && ass.Namespaces != null && ass.Namespaces.Any())
            {
                return ass.Namespaces.Where(p => p.Name != null).ToArray();
            }
            return null;
        }

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public bool Delete(Guid id)
        //{
        //    return true;
        //}
    }
}