using AutoHelp.domain.Helpers;
using AutoHelp.domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Exception = System.Exception;

namespace AutoHelp.domain.Services
{
    public class DocServices
    {
       public string DataPath { get; set; }

        public DocServices(string path = null)
        {
            this.DataPath = path;
        }

        public List<Assembly> SetAssemblies()
        {
            var fileList = this.GetFilesList();

            return fileList.Select(file => this.GetNamespace(file)).ToList();
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
