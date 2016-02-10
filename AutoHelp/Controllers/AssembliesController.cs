using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoHelp.domain.Models;

namespace AutoHelp.Controllers
{
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