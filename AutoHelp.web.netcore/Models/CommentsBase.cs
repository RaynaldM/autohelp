using System.Globalization;
using System.Runtime.Serialization;

namespace AutoHelp.web.netcore.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CommentsBase
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Fullname { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string Returns { get; set; }
        [DataMember]
        public string Example { get; set; }
        [DataMember]
        public string Exceptions { get; set; }
        [IgnoreDataMember]
        public bool UseHashCodeForId { get; set; }
        [DataMember]
        public string Id => UseHashCodeForId ? Fullname.GetHashCode().ToString(CultureInfo.InvariantCulture) : Name;

        [DataMember]
        public bool LoadError { get; set; }

        // Exceptions, SeeAlso

        public CommentsBase()
        {
            Fullname = "";
            Summary = "";
            Remarks = "";
            Returns = "";
            Example = "";
            Exceptions = "";
        }
    }
}
