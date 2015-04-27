// ----------------------------------------------------------------------------
// IXmlDocCommentReader.cs
//
// Contains the definition of the IXmlDocCommentReader interface.
// Copyright 2009 Steve Guidi.
//
// File created: 3/1/2009 11:04:59
// ----------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Xml.Linq;

namespace Jolt
{
    /// <summary>
    /// An internal interface supporting the testing of objects
    /// that have and/or use an <see cref="XmlDocCommentReader"/>.
    /// </summary>
    internal interface IXmlDocCommentReader
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