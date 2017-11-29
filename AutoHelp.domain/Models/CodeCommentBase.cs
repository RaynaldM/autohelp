using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AutoHelp.domain.Models
{
    public abstract class CodeCommentBase : CommentsBase
    {
        [IgnoreDataMember]
        public TypeBase Parent { get; set; }
        [DataMember]
        public string ParentClass { get; set; }
        [DataMember]
        public IList<Parameter> Parameters { get; set; }
        [DataMember]
        public string formatedParams => this.ParameterTypes();

        /// <summary>
        /// Returns the parameters types, comma seperated.
        /// </summary>
        /// <returns></returns>
        public string ParameterTypes()
        {
            if (Parameters == null || !Parameters.Any())
                return string.Empty;

            var list = Parameters.Select(parameter => parameter.Type).ToList();

            return string.Join(",", list);
        }
    }
}
