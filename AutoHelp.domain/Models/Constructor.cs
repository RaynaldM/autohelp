using System.Diagnostics;
using System.Runtime.Serialization;

namespace AutoHelp.domain.Models
{
    [DebuggerDisplay("{Fullname}")]
    [DataContract]
    public class Constructor : CodeCommentBase
    {
        [DataMember]
        public string Attributes { get; set; } 
    }
}
