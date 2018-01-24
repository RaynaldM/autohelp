using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace AutoHelp.web.netcore.Models
{
    [DebuggerDisplay("{Fullname}")]
    [DataContract]
    public class TypeBase : CommentsBase
    {
        [IgnoreDataMember]
        public Namespace Namespace { get; set; }
        [DataMember]
        public string ParentClass { get; set; }
        [DataMember]
        public List<TypeSummary> Parents { get; set; }

        /// <summary>
        /// Returns one of these: Class,Interfact, Structure,Enumeration,Delegate
        /// </summary>
        [DataMember]
        public string ObjectType { get; set; }

        [DataMember]
        public bool IsPublic { get; set; }
        [DataMember]
        public bool IsSealed { get; set; }
        [DataMember]
        public bool IsAbstract { get; set; }
        [DataMember]
        public bool IsPrimitive { get; set; }
        [DataMember]
        public bool IsNested { get; set; }

        [DataMember]
        public IList<Constructor> Constructors { get; set; }
        [DataMember]
        public IList<Method> Methods { get; set; }
        [DataMember]
        public IList<Property> Properties { get; set; }
        [DataMember]
        public IList<MemberSummary> Members { get; set; }

        public TypeBase()
        {
            Constructors = new List<Constructor>();
            Methods = new List<Method>();
            Properties = new List<Property>();
            Members = new List<MemberSummary>();
            Parents = new List<TypeSummary>();
        }
    }

    [DebuggerDisplay("{Fullname}")]
    public class TypeSummary
    {
        public string Name { get; set; }
        public string Fullname { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class MemberSummary
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
