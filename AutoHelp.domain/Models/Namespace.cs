using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AutoHelp.domain.Models
{
    [DebuggerDisplay("{Assembly}")]
    public class Assembly
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string FileName { get; set; }
        public Guid Id { get; set; }
   
        public IList<Namespace> Namespaces { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class Namespace
    {
        public string Name { get; set; }
        public IList<TypeBase> Classes { get; set; }
        public IList<TypeBase> Interfaces { get; set; }
        public IList<TypeBase> Structures { get; set; }
        public IList<TypeBase> Enumerations { get; set; }
        public IList<TypeBase> Delegates { get; set; }
        public IList<TypeBase> AllTypes
        {
            get
            {
                return Classes.Union(Interfaces).Union(Structures).Union(Enumerations).Union(Delegates).OrderBy(t => t.Name).ToList();
            }
        }

        public Namespace()
        {
            Classes = new List<TypeBase>();
            Interfaces = new List<TypeBase>();
            Structures = new List<TypeBase>();
            Enumerations = new List<TypeBase>();
            Delegates = new List<TypeBase>();
        }

        public override string ToString()
        {
            return Name;
        }

        // ReSharper disable once CSharpWarnings::CS0659
        public override bool Equals(object obj)
        {
            var b = obj as Namespace;
            if (b == null)
                return false;

            return Name == b.Name;
        }

        public int CountAlltype { get { return this.AllTypes.Count; } }
      }
}
