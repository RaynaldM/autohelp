using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace AutoHelp.domain.Models
{
    [DebuggerDisplay("{Fullname}")]
    [DataContract]
    public class Method : CodeCommentBase
    {
        [DataMember]
        public string ReturnType { get; set; }
        [DataMember]
        public string ReturnTypeFullName { get; set; }

        public Method()
        {
            Parameters = new List<Parameter>();
        }
    }
}