using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Sentio.MixedService.Tests.TestModel
{
    public static class TestHelper
    {
        public static string Serialize<T>(this T value)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value, emptyNamepsaces);
                return stream.ToString();
            }
        }
    }
    public class XMLJsonTester
    {
        public string XmlJsonProp1 { get; set; }
        public string XmlJsonProp2 { get; set; }
        public string XmlJsonProp3 { get; set; }
        public string XmlJsonProp4 { get; set; }
        public string XmlJsonProp5 { get; set; }
    }

    public class DeserializeContent
    {
        public XMLJsonTester XMLJsonTester { get; set; }
    }
}
