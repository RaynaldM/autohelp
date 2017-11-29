using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoHelp.domain.Helpers.XMLHelper.Interfaces
{
    /// <summary>
    /// An internal interface supporting the testing of objects
    /// that have and/or use an <see cref="XmlDocCommentReader"/>.
    /// </summary>
    interface IXmlDocCommentReader
    {
        XElement GetComments(ConstructorInfo constructor);
        XElement GetComments(EventInfo eventInfo);
        XElement GetComments(FieldInfo field);
        XElement GetComments(MethodInfo method);
        XElement GetComments(MemberInfo member);
        XElement GetComments(PropertyInfo property);
        XElement GetComments(Type type);
    }

}
