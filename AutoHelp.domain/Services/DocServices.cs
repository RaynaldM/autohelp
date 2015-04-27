using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoHelp.domain.Helpers;
using AutoHelp.domain.Models;
using Exception = System.Exception;

namespace AutoHelp.domain.Services
{
    public class DocServices
    {
       public string DataPath { get; private set; }

        public DocServices(string path = null)
        {
            this.DataPath = path;
        }

        public List<Assembly> SetAssemblies()
        {
            var fileList = this.GetFilesList();

            return fileList.Select(file => this.GetNamespace(file)).ToList();
        }

        public Boolean DeletePhysicalFile(String filename)
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

        private Assembly GetNamespace(String file, Boolean bParseNamespace = true)
        {
            var parser = new DocParser();
            var assembly = parser.Parse(file, bParseNamespace);
            assembly.FileName = file;
            return assembly;
        }


        private IEnumerable<string> GetFilesList()
        {
            var filesList = new List<String>();
            if (this.DataPath != null && Directory.Exists(this.DataPath))
            {
                var dllList = Directory.EnumerateFiles(this.DataPath, "*.dll");
                foreach (var file in dllList)
                {
                    if (File.Exists(file.Replace(".dll", ".xml")))
                    {
                        //     filesList.Add(file.Substring(file.LastIndexOf(@"\", StringComparison.Ordinal) + 1));
                        filesList.Add(file);
                    }
                }
            }

            return filesList;
        }
    }
}
