using System.Diagnostics;
using System.Runtime.Serialization;

namespace AutoHelp.web.netcore.Models
{
    [DebuggerDisplay("{Fullname}")]
    [DataContract]
    public class Constructor : CodeCommentBase
    {
        [DataMember]
        public string Attributes { get; set; } 
    }
}
