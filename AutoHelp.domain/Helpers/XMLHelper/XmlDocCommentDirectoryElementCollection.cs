using System.Collections.Generic;
using System.Configuration;

namespace AutoHelp.domain.Helpers.XMLHelper
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
#pragma warning disable 1584, 1711, 1572, 1581, 1580
        /// <see cref="ConfigurationElement.CreateNewElement()"/>
#pragma warning restore 1584, 1711, 1572, 1581, 1580
        /// </summary>
        protected override ConfigurationElement CreateNewElement()
        {
            return new XmlDocCommentDirectoryElement();
        }

        /// <summary>
#pragma warning disable 1584,1711,1572,1581,1580
        /// <see cref="ConfigurationElement.CreateNewElement(string)"/>
#pragma warning restore 1584,1711,1572,1581,1580
        /// </summary>
        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new XmlDocCommentDirectoryElement(elementName);
        }

        /// <summary>
#pragma warning disable 1584,1711,1572,1581,1580
        /// <see cref="ConfigurationElement.GetElementKey(ConfigurationElement)"/>
#pragma warning restore 1584,1711,1572,1581,1580
        /// </summary>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((XmlDocCommentDirectoryElement)element).Name;
        }

        #endregion
    }

}
