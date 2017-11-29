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
            return ass?.Namespaces != null && ass.Namespaces.Any()
                ? ass.Namespaces.Where(p => p.Name != null).ToArray()
                : null;
        }
    }
}