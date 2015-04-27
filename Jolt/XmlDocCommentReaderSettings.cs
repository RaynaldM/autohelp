// ----------------------------------------------------------------------------
// XmlDocCommentReaderSettings.cs
//
// Contains the definition of the XmlDocCommentReaderSettings class.
// Copyright 2009 Steve Guidi.
//
// File created: 2/1/2009 09:23:43
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace Jolt
{
    /// <summary>
    /// Provides configuration settings to control the search paths
    /// for locating XML doc comments.
    /// </summary>
    public sealed class XmlDocCommentReaderSettings : ConfigurationSection
    {
        #region constructors ----------------------------------------------------------------------

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentReaderSettings"/> class
        /// with an empty search paths collection.
        /// </summary>
        public XmlDocCommentReaderSettings() { }

        /// <summary>
        /// Creates a new instance of the <see cref="XmlDocCommentReaderSettings"/> class
        /// with the given directory names.
        /// </summary>
        /// 
        /// <param name="docCommentDirectoryNames">
        /// The search paths used to locate an XML doc comments file.
        /// </param>
        public XmlDocCommentReaderSettings(IEnumerable<string> docCommentDirectoryNames)
        {
            this["XmlDocCommentDirectories"] = new XmlDocCommentDirectoryElementCollection(docCommentDirectoryNames);
        }

        #endregion

        #region public properties -----------------------------------------------------------------

        /// <summary>
        /// Gets the collection of search paths.
        /// </summary>
        [ConfigurationProperty("XmlDocCommentDirectories", IsRequired = true)]
        [ConfigurationCollection(typeof(XmlDocCommentDirectoryElementCollection), AddItemName = "Directory")]
        public XmlDocCommentDirectoryElementCollection DirectoryNames
        {
            get { return (XmlDocCommentDirectoryElementCollection)this["XmlDocCommentDirectories"]; }
        }

        #endregion

        #region public fields ---------------------------------------------------------------------

        /// <summary>
        /// Stores an instance of the default configuration.
        /// </summary>
        public static readonly XmlDocCommentReaderSettings Default = CreateDefaultSettings();

        #endregion

        #region private methods -------------------------------------------------------------------

        /// <summary>
        /// Creates the default <see cref="XmlDocCommentReaderSettings"/> object.
        /// </summary>
        /// 
        /// <remarks>
        /// Searches the application's working directory, followed by each .NET Framework
        /// reference assembly directory, including 64bit variants.
        /// </remarks>
        /// 
        /// <returns>
        /// A new instance of an <see cref="XmlDocCommentReaderSettings"/> object, with a
        /// predefined list of search paths.
        /// </returns>
        private static XmlDocCommentReaderSettings CreateDefaultSettings()
        {
            const string framework = "Framework";
            var netfxSubDirectoryName = Path.Combine("Microsoft.NET", framework);
            var referenceAssembliesSubDirectoryName = Path.Combine("Reference Assemblies", Path.Combine("Microsoft", framework));
            var programFilesDirectoryName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            // ReSharper disable once AssignNullToNotNullAttribute
            var netfxDirectoryName = Path.Combine(Path.GetDirectoryName(Environment.SystemDirectory), netfxSubDirectoryName);
            var referenceAssembliesDirectoryNameX86 = Path.Combine(programFilesDirectoryName, referenceAssembliesSubDirectoryName);
            var referenceAssembliesDirectoryName = Path.Combine(programFilesDirectoryName + " (x86)", referenceAssembliesSubDirectoryName);

            var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var netfx3_0 = Path.Combine("3.0", culture);
            const string netfx3_5 = "3.5";

            return new XmlDocCommentReaderSettings(new[]
            {
                Environment.CurrentDirectory,
                Path.Combine(referenceAssembliesDirectoryName, netfx3_5),
                Path.Combine(referenceAssembliesDirectoryNameX86, netfx3_5),
                Path.Combine(referenceAssembliesDirectoryName, netfx3_0),
                Path.Combine(referenceAssembliesDirectoryNameX86, netfx3_0),
                Path.Combine(netfxDirectoryName, Path.Combine(@"v2.0.50727", culture)),
                Path.Combine(netfxDirectoryName, @"v1.1.4322"),
                Path.Combine(netfxDirectoryName, @"v1.0.3705")
            });
        }

        #endregion
    }
}