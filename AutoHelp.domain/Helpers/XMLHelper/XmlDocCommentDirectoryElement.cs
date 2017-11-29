using System.Configuration;

namespace AutoHelp.domain.Helpers.XMLHelper
{
    /// <summary>
    /// Provides configuration settings for specifying the search paths
    /// to locate XML doc comments.  Represents an element that
    /// contains one such search path.
    /// </summary>
    public sealed class XmlDocCommentDirectoryElement : ConfigurationElement
    {
        #region constructors ----------------------------------------------------------------------

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentDirectoryElement"/>
        /// class, with the given directory name.
        /// </summary>
        /// 
        /// <param name="directoryName">
        /// The directory name containing a user desired search path.
        /// </param>
        public XmlDocCommentDirectoryElement(string directoryName)
        {
            this["name"] = directoryName;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentDirectoryElement"/>
        /// class, with the default directory name.
        /// </summary>
        /// 
        /// <remarks>
        /// Intended to be called by an XML serializer.
        /// </remarks>
        internal XmlDocCommentDirectoryElement() { }

        #endregion

        #region public properties -----------------------------------------------------------------

        /// <summary>
        /// Gets the directory name value stored in the configuration element.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name => this["name"] as string;

        #endregion
    }
}
