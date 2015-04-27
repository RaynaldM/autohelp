// ----------------------------------------------------------------------------
// XmlDocCommentNames.cs
//
// Contains the definition of the XmlDocCommentNames class.
// Copyright 2009 Steve Guidi.
//
// File created: 3/12/2009 19:06:58
// ----------------------------------------------------------------------------

namespace Jolt
{
    /// <summary>
    /// Contains string literals pertaining to element/attribute names found in an
    /// XML doc comment document.
    /// </summary>
    internal sealed class XmlDocCommentNames
    {
        internal static readonly string DocElement = "doc";
        internal static readonly string AssemblyElement = "assembly";
        internal static readonly string NameElement = "name";
        internal static readonly string MembersElement = "members";
        internal static readonly string MemberElement = "member";
        internal static readonly string NameAttribute = NameElement;
    }
}