using System.Diagnostics;
using System.Runtime.Serialization;

namespace AutoHelp.domain.Models
{
    [DebuggerDisplay("{Fullname}")]
    [DataContract]
    public class Property : CommentsBase
    {
        [IgnoreDataMember]
        public TypeBase Parent { get; set; }
        [DataMember]
        public string ParentClass { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string TypeFullName { get; set; }
        [DataMember]
        public string Attributes { get; set; }

        //info.IsStatic;
        //info.IsPublic;
        //info.IsPrivate;
        //info.IsGenericMethod;
        //info.IsVirtual;
        //info.IsFinal;
        //info.IsAbstract;

    }
}
