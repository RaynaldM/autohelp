// ----------------------------------------------------------------------------
// XmlDocCommentReader.cs
//
// Contains the definition of the XmlDocCommentReader class.
// Copyright 2008 Steve Guidi.
//
// File created: 12/28/2008 22:49:42
// ----------------------------------------------------------------------------

using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

using Jolt.GeneratedTypes.System.IO;
using Jolt.Properties;

namespace Jolt
{
    // Represents a factory method for creating types that implement
    // the IXmlDocCommentReadPolicy interface.  The string parameter
    // contains the full path of the XML doc comment file that is to
    // be read by the policy.
    using CreateReadPolicyDelegate=Func<string, IXmlDocCommentReadPolicy>;


    /// <summary>
    /// Provides methods to retrieve the XML Documentation Comments for an
    /// object having a metadata type from the System.Reflection namespace.
    /// </summary>
    public sealed class XmlDocCommentReader : IXmlDocCommentReader
    {
        #region constructors ----------------------------------------------------------------------

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentReader"/> class
        /// by searching for a doc comments file that corresponds to the given assembly.
        /// </summary>
        /// 
        /// <param name="assembly">
        /// The <see cref="System.Reflection.Assembly"/> whose doc comments are retrieved.
        /// </param>
        /// 
        /// <remarks>
        /// Searches in the application's configured search paths, if any.
        /// </remarks>
        public XmlDocCommentReader(Assembly assembly)
            : this(assembly, CreateDefaultReadPolicy) { }

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentReader"/> class
        /// by searching for a doc comments file that corresponds to the given assembly.
        /// Configures the reader to use a user-defined read policy.
        /// </summary>
        /// 
        /// <param name="assembly">
        /// The <see cref="System.Reflection.Assembly"/> whose doc comments are retrieved.
        /// </param>
        /// 
        /// <param name="createReadPolicy">
        /// A factory method that accepts the full path to an XML doc comments file,
        /// returning a user-defined read policy.
        /// </param>
        /// 
        /// <remarks>
        /// Searches in the application's configured search paths, if any.
        /// </remarks>
        public XmlDocCommentReader(Assembly assembly, CreateReadPolicyDelegate createReadPolicy)
            : this(assembly, ConfigurationManager.GetSection("XmlDocCommentsReader") as XmlDocCommentReaderSettings, createReadPolicy) { }

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentReader"/> class
        /// by searching for a doc comments file that corresponds to the given assembly.
        /// Searches the given paths, and configures the reader to use a user-defined read policy.
        /// </summary>
        /// 
        /// <param name="assembly">
        /// The <see cref="System.Reflection.Assembly"/> whose doc comments are retrieved.
        /// </param>
        /// 
        /// <param name="settings">
        /// The <see cref="XmlDocCommentReaderSettings"/> object containing the doc comment search paths.
        /// </param>
        /// 
        /// <param name="createReadPolicy">
        /// A factory method that accepts the full path to an XML doc comments file,
        /// returning a user-defined read policy.
        /// </param>
        public XmlDocCommentReader(Assembly assembly, XmlDocCommentReaderSettings settings, CreateReadPolicyDelegate createReadPolicy)
            : this(assembly, settings, DefaultFileProxy, createReadPolicy) { }

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentReader"/> class
        /// with a given path to the XML doc comments.
        /// </summary>
        /// 
        /// <param name="docCommentsFullPath">
        /// The full path of the XML doc comments.
        /// </param>
        public XmlDocCommentReader(string docCommentsFullPath)
            : this(docCommentsFullPath, CreateDefaultReadPolicy) { }

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentReader"/> class
        /// with a given path to the XML doc comments, and configures the reader
        /// to use a user-defined read policy.
        /// </summary>
        /// 
        /// <param name="docCommentsFullPath">
        /// The full path of the XML doc comments.
        /// </param>
        /// 
        /// <param name="createReadPolicy">
        /// A factory method that accepts the full path to an XML doc comments file,
        /// returning a user-defined read policy.
        /// </param>
        public XmlDocCommentReader(string docCommentsFullPath, CreateReadPolicyDelegate createReadPolicy)
            : this(docCommentsFullPath, DefaultFileProxy, createReadPolicy(docCommentsFullPath)) { }


        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentReader"/> class
        /// by searching for a doc comments file that corresponds to the given assembly.
        /// Searches the given paths, and configures the reader to use a user-defined read policy.
        /// </summary>
        /// 
        /// <param name="assembly">
        /// The <see cref="System.Reflection.Assembly"/> whose doc comments are retrieved.
        /// </param>
        /// 
        /// <param name="settings">
        /// The <see cref="XmlDocCommentReaderSettings"/> object containing the doc comment search paths.
        /// </param>
        /// 
        /// <param name="fileProxy">
        /// The proxy to the file system.
        /// </param>
        /// 
        /// <param name="createReadPolicy">
        /// A factory method that accepts the full path to an XML doc comments file,
        /// returning a user-defined read policy.
        /// </param>
        /// 
        /// <remarks>
        /// Used internally by test code to override file IO operations.
        /// </remarks>
        internal XmlDocCommentReader(Assembly assembly, XmlDocCommentReaderSettings settings, IFile fileProxy, CreateReadPolicyDelegate createReadPolicy)
        {
            m_settings = settings ?? XmlDocCommentReaderSettings.Default;
            m_docCommentsFullPath = ResolveDocCommentsLocation(assembly, m_settings.DirectoryNames, fileProxy);
            m_fileProxy = fileProxy;
            m_docCommentsReadPolicy = createReadPolicy(m_docCommentsFullPath);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentReader"/> class
        /// with a given path to the XML doc comments, and configures the reader
        /// to use a user-defined read policy.
        /// </summary>
        /// 
        /// <param name="docCommentsFullPath">
        /// The full path of the XML doc comments.
        /// </param>
        /// 
        /// <param name="fileProxy">
        /// The proxy to the file system.
        /// </param>
        /// 
        /// <param name="readPolicy">
        /// The doc comment read policy.
        /// </param>
        /// 
        /// <remarks>
        /// Used internally by test code to override file IO operations.
        /// </remarks>
        /// 
        /// <exception cref="System.IO.FileNotFoundException">
        /// <paramref name="docCommentsFullPath"/> could does not exist or is inaccessible.
        /// </exception>
        internal XmlDocCommentReader(string docCommentsFullPath, IFile fileProxy, IXmlDocCommentReadPolicy readPolicy)
        {
            if (!fileProxy.Exists(docCommentsFullPath))
            {
                throw new FileNotFoundException(
                    String.Format(Resources.Error_XmlDocComments_FileNotFound, docCommentsFullPath),
                    docCommentsFullPath);
            }

            m_fileProxy = fileProxy;
            m_docCommentsFullPath = docCommentsFullPath;
            m_docCommentsReadPolicy = readPolicy;
            m_settings = XmlDocCommentReaderSettings.Default;
        }

        #endregion
        
        #region public methods --------------------------------------------------------------------

        /// <summary>
        /// Retrieves the xml doc comments for a given <see cref="System.Type"/>.
        /// </summary>
        /// 
        /// <param name="type">
        /// The <see cref="System.Type"/> for which the doc comments are retrieved.
        /// </param>
        /// 
        /// <returns>
        /// An <see cref="XElement"/> containing the requested XML doc comments,
        /// or NULL if none were found.
        /// </returns>
        public XElement GetComments(Type type)
        {
            return m_docCommentsReadPolicy.ReadMember(Convert.ToXmlDocCommentMember(type));
        }

        /// <summary>
        /// Retrieves the xml doc comments for a given <see cref="System.Reflection.EventInfo"/>.
        /// </summary>
        /// 
        /// <param name="eventInfo">
        /// The <see cref="System.Reflection.EventInfo"/> for which the doc comments are retrieved.
        /// </param>
        /// 
        /// <returns>
        /// An <see cref="XElement"/> containing the requested XML doc comments,
        /// or NULL if none were found.
        /// </returns>
        public XElement GetComments(EventInfo eventInfo)
        {
            return m_docCommentsReadPolicy.ReadMember(Convert.ToXmlDocCommentMember(eventInfo));
        }

        /// <summary>
        /// Retrieves the xml doc comments for a given <see cref="System.Reflection.FieldInfo"/>.
        /// </summary>
        /// 
        /// <param name="field">
        /// The <see cref="System.Reflection.FieldInfo"/> for which the doc comments are retrieved.
        /// </param>
        /// 
        /// <returns>
        /// An <see cref="XElement"/> containing the requested XML doc comments,
        /// or NULL if none were found.
        /// </returns>
        public XElement GetComments(FieldInfo field)
        {
            return m_docCommentsReadPolicy.ReadMember(Convert.ToXmlDocCommentMember(field));
        }

        /// <summary>
        /// Retrieves the xml doc comments for a given <see cref="System.Reflection.PropertyInfo"/>.
        /// </summary>
        /// 
        /// <param name="property">
        /// The <see cref="System.Reflection.PropertyInfo"/> for which the doc comments are retrieved.
        /// </param>
        /// 
        /// <returns>
        /// An <see cref="XElement"/> containing the requested XML doc comments,
        /// or NULL if none were found.
        /// </returns>
        public XElement GetComments(PropertyInfo property)
        {
            return m_docCommentsReadPolicy.ReadMember(Convert.ToXmlDocCommentMember(property));
        }

        /// <summary>
        /// Retrieves the xml doc comments for a given <see cref="System.Reflection.ConstructorInfo"/>.
        /// </summary>
        /// 
        /// <param name="constructor">
        /// The <see cref="System.Reflection.ConstructorInfo"/> for which the doc comments are retrieved.
        /// </param>
        /// 
        /// <returns>
        /// An <see cref="XElement"/> containing the requested XML doc comments,
        /// or NULL if none were found.
        /// </returns>
        public XElement GetComments(ConstructorInfo constructor)
        {
            return m_docCommentsReadPolicy.ReadMember(Convert.ToXmlDocCommentMember(constructor));
        }

        /// <summary>
        /// Retrieves the xml doc comments for a given <see cref="System.Reflection.MethodInfo"/>.
        /// </summary>
        /// 
        /// <param name="method">
        /// The <see cref="System.Reflection.MethodInfo"/> for which the doc comments are retrieved.
        /// </param>
        /// 
        /// <returns>
        /// An <see cref="XElement"/> containing the requested XML doc comments,
        /// or NULL if none were found.
        /// </returns>
        public XElement GetComments(MethodInfo method)
        {
            return m_docCommentsReadPolicy.ReadMember(Convert.ToXmlDocCommentMember(method));
        }

		public XElement GetComments(MemberInfo member)
		{
			return m_docCommentsReadPolicy.ReadMember(Convert.ToXmlDocCommentMember(member));
		}
        #endregion

        #region public properties -----------------------------------------------------------------

        /// <summary>
        /// Gets the full path to the XML doc comments file that is
        /// read by the reader.
        /// </summary>
        public string FullPath
        {
            get { return m_docCommentsFullPath; }
        }

        /// <summary>
        /// Gets the configuration settings associated with this object.
        /// </summary>
        public XmlDocCommentReaderSettings Settings
        {
            get { return m_settings; }
        }

        #endregion

        #region internal properties ---------------------------------------------------------------

        /// <summary>
        /// Gets the file proxy used by the class.
        /// </summary>
        internal IFile FileProxy
        {
            get { return m_fileProxy; }
        }

        /// <summary>
        /// Gets the read policy used by the class.
        /// </summary>
        internal IXmlDocCommentReadPolicy ReadPolicy
        {
            get { return m_docCommentsReadPolicy; }
        }

        #endregion

        #region private methods -------------------------------------------------------------------

        /// <summary>
        /// Locates the XML doc comment file corresponding to the given
        /// <see cref="System.Reflection.Assembly"/>, in the given directories.
        /// </summary>
        /// 
        /// <param name="assembly">
        /// The assembly whose doc comments are retrieved.
        /// </param>
        /// 
        /// <param name="directories">
        /// The directory names to search.
        /// </param>
        /// 
        /// <param name="fileProxy">
        /// The proxy to the file system.
        /// </param>
        /// 
        /// <returns>
        /// The full path to the requested XML doc comment file, if it exists.
        /// </returns>
        /// 
        /// <exception cref="System.IO.FileNotFoundException">
        /// The XML doc comments file was not found, for the given set of parameters.
        /// </exception>
        private static string ResolveDocCommentsLocation(Assembly assembly, XmlDocCommentDirectoryElementCollection directories, IFile fileProxy)
        {
            string assemblyFileName = assembly.GetName().Name;
            string xmlDocCommentsFilename = String.Concat(assemblyFileName, XmlFileExtension);

            foreach (XmlDocCommentDirectoryElement directory in directories)
            {
                string xmlDocCommentsFullPath = Path.GetFullPath(Path.Combine(directory.Name, xmlDocCommentsFilename));
                if (fileProxy.Exists(xmlDocCommentsFullPath))
                {
                    return xmlDocCommentsFullPath;
                }
            }

            throw new FileNotFoundException(
                String.Format(Resources.Error_XmlDocComments_AssemblyNotResolved, assemblyFileName),
                assemblyFileName);
        }

        #endregion

        #region private fields --------------------------------------------------------------------

        private readonly IFile m_fileProxy;
        private readonly string m_docCommentsFullPath;
        private readonly IXmlDocCommentReadPolicy m_docCommentsReadPolicy;
        private readonly XmlDocCommentReaderSettings m_settings;

        private static readonly IFile DefaultFileProxy = new FileProxy();
        private static readonly CreateReadPolicyDelegate CreateDefaultReadPolicy = path => new DefaultXDCReadPolicy(path, DefaultFileProxy);
        private static readonly string XmlFileExtension = ".xml";

        #endregion
    }
}