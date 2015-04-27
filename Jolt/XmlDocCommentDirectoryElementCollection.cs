// ----------------------------------------------------------------------------
// XmlDocCommentDirectoryElementCollection.cs
//
// Contains the definition of the XmlDocCommentDirectoryElementCollection class.
// Copyright 2009 Steve Guidi.
//
// File created: 2/1/2009 09:33:01
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Configuration;

namespace Jolt
{
    /// <summary>
    /// Provides configuration settings for specifying the search paths
    /// to locate XML doc comments.  Represents an element that
    /// aggregates such search paths.
    /// </summary>
    public sealed class XmlDocCommentDirectoryElementCollection : ConfigurationElementCollection
    {
        #region constructors ----------------------------------------------------------------------

        /// <summary>
        /// Creates an new instance of the <see cref="XmlDocCommentDirectoryElementCollection"/>
        /// class with no search paths.
        /// </summary>
        public XmlDocCommentDirectoryElementCollection() { }

        /// <summary>
        /// Creates an new instance of the <see cref="XmlDocCommentDirectoryElementCollection"/>
        /// with the given search paths.
        /// </summary>
        /// 
        /// <param name="directoryNames">
        /// The desired XML doc comment search paths.
        /// </param>
        public XmlDocCommentDirectoryElementCollection(IEnumerable<string> directoryNames)
        {
            foreach (string directoryName in directoryNames)
            {
                this.BaseAdd(new XmlDocCommentDirectoryElement(directoryName));
            }
        }

        #endregion

        #region ConfigurationElementCollection members --------------------------------------------

        /// <summary>
        /// <see cref="ConfigurationElement.CreateNewElement()"/>
        /// </summary>
        protected override ConfigurationElement CreateNewElement()
        {
            return new XmlDocCommentDirectoryElement();
        }

        /// <summary>
        /// <see cref="ConfigurationElement.CreateNewElement(string)"/>
        /// </summary>
        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new XmlDocCommentDirectoryElement(elementName);
        }

        /// <summary>
        /// <see cref="ConfigurationElement.GetElementKey(ConfigurationElement)"/>
        /// </summary>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((XmlDocCommentDirectoryElement)element).Name;
        }

        #endregion
    }
}