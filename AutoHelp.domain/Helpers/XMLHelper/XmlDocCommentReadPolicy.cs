using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using AutoHelp.domain.Helpers.XMLHelper.Interfaces;

namespace AutoHelp.domain.Helpers.XMLHelper
{

    public class XmlDocCommentReadPolicy : IXmlDocCommentReadPolicy
    {
        private readonly XmlReaderSettings ReaderSettings;

        private readonly XDocument m_docComments;
        private string XmlDocCommentsFullPath { get; }

        public XmlDocCommentReadPolicy(string xmlDocCommentsFullPath)

        {
            this.ReaderSettings = new XmlReaderSettings { ValidationType = ValidationType.Schema };

            Type thisType = typeof(XmlDocCommentReadPolicy);
            using (Stream schema = thisType.Assembly.GetManifestResourceStream("AutoHelp.domain.Xml.DocComments.xsd"))
            {
                ReaderSettings.Schemas.Add(XmlSchema.Read(schema ?? throw new InvalidOperationException("DocComments.xsd not found"), null));
            }

            this.XmlDocCommentsFullPath = xmlDocCommentsFullPath;
            using (XmlReader reader = CreateReader())
            {
                m_docComments = XDocument.Load(reader);
            }
        }

        protected XmlReader CreateReader()
        {
            return XmlReader.Create(File.OpenText(XmlDocCommentsFullPath), ReaderSettings);
        }

        /// <summary>
        /// <see cref="IXmlDocCommentReadPolicy.ReadMember"/>
        /// </summary>
        XElement IXmlDocCommentReadPolicy.ReadMember(string memberName)
        {
            XElement member = m_docComments
                .Element(XmlDocCommentNames.DocElement)
                ?.Element(XmlDocCommentNames.MembersElement)
                ?.Elements(XmlDocCommentNames.MemberElement)
                .SingleOrDefault(e => e.Attribute(XmlDocCommentNames.NameAttribute)?.Value == memberName);

            // Copy the <member> element from the DOM.
            return member == null ? null : XElement.Load(member.CreateReader());
        }
    }

    internal class XmlDocCommentNames
    {
        internal static readonly string DocElement = "doc";
        internal static readonly string AssemblyElement = "assembly";
        internal static readonly string NameElement = "name";
        internal static readonly string MembersElement = "members";
        internal static readonly string MemberElement = "member";
        internal static readonly string NameAttribute = NameElement;
    }
}
