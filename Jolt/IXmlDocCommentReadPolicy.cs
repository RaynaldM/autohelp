// ----------------------------------------------------------------------------
// IXmlDocCommentReadPolicy.cs
//
// Contains the definition of the IXmlDocCommentReadPolicy interface.
// Copyright 2009 Steve Guidi.
//
// File created: 2/17/2009 8:27:14 AM
// ----------------------------------------------------------------------------

using System.Xml.Linq;

namespace Jolt
{
    /// <summary>
    /// Defines a contract for retrieving XML data from any
    /// XML doc comment data store.
    /// </summary>
    public interface IXmlDocCommentReadPolicy
    {
        /// <summary>
        /// Reads the XML indexed by the member of the given name from the
        /// underlying store.
        /// </summary>
        /// 
        /// <param name="memberName">
        /// The name of the member for which the XML doc comments are read.
        /// </param>
        /// 
        /// <returns>
        /// An <see cref="XElement"/> containing the requested XML doc comments.
        /// </returns>
        XElement ReadMember(string memberName);
    }
}