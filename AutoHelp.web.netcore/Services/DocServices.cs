using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoHelp.web.netcore.Helpers;
using AutoHelp.web.netcore.Models;
using Exception = System.Exception;

namespace AutoHelp.web.netcore.Services
{
    public interface IDocServices
    {
        IEnumerable<Assembly> Assemblies { get; }
        string DataPath { get; set; }
        IEnumerable<Assembly> GetAssembliesList();
        Assembly GetAssembly(Guid id);
        bool DeletePhysicalFile(string filename);
    }

    public class DocServices : IDocServices
    {
        private IEnumerable<Assembly> _assemblies;

        public IEnumerable<Assembly> Assemblies => this._assemblies ?? (this._assemblies = this.InitAssemblies());

        public string DataPath { get; set; }

        public DocServices(string path = null)
        {
            this.DataPath = path;
        }

        private IEnumerable<Assembly> InitAssemblies()
        {
            var fileList = this.GetFilesList();

            return fileList.Select(file => this.GetNamespace(file)).ToArray();
        }

        public IEnumerable<Assembly> GetAssembliesList()
        {
            return this.Assemblies.Select(assembly => new Assembly
            {
                Id = assembly.Id,
                Name = assembly.Name,
                FullName = assembly.FullName,
                Namespaces = null
            }).ToArray();
        }

        public Assembly GetAssembly(Guid id)
        {
            return this.Assemblies.SingleOrDefault(p => p.Id == id);
        }
        
        public bool DeletePhysicalFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    filename = filename.Replace(".dll", ".xml");
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private Assembly GetNamespace(string file, bool bParseNamespace = true)
        {
            var parser = new DocParser();
            var assembly = parser.Parse(file, bParseNamespace);
            assembly.FileName = file;
            return assembly;
        }

        private IEnumerable<string> GetFilesList()
        {
            var filesList = new List<string>();
            if (this.DataPath != null && Directory.Exists(this.DataPath))
            {
                var dllList = Directory.EnumerateFiles(this.DataPath, "*.dll");
                filesList.AddRange(dllList.Where(file => File.Exists(file.Replace(".dll", ".xml"))));
            }

            return filesList;
        }
    }
}
