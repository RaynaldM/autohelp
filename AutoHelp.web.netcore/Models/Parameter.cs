using System.Runtime.Serialization;

namespace AutoHelp.web.netcore.Models
{
    [DataContract]
    public class Parameter
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string TypeFullName { get; set; }
        [DataMember]
        public string Attributes { get; set; }
        [DataMember]
        public bool IsOut { get; set; }
        [DataMember]
        public bool IsRet { get; set; }

        public override string ToString()
        {
            return Type + " " + Name;
        }
    }
}
