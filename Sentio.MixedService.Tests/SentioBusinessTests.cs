using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Sentio.BusinessLogic;
using Sentio.MixedService.Tests.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.MixedService.Tests
{
    [TestClass]
    public class SentioBusinessTests
    {
        [TestMethod]
        public void Fibonacci()
        {
            var result = ServiceLogic.Fibonacci(6);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void XmlToJson()
        {
            // Arrange
            string result = ServiceLogic.XmlToJson("<foo>hello</bar>");
            Assert.AreEqual("Bad Xml format", result);

            result = ServiceLogic.XmlToJson("<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>");
            Assert.AreNotEqual(result, "Bad Xml format");
            var testObject = new XMLJsonTester
            {
                XmlJsonProp1 = "Scott Hall A.K.A. Razor Ramon",
                XmlJsonProp2 = "Kevin Nash A.K.A. Disel",
                XmlJsonProp3 = "Sean Waltman A.K.A. 1 2 3 Kid",
                XmlJsonProp4 = "Hulk Hogan A.K.A. Hollywood",
                XmlJsonProp5 = "Jake Roberts A.K.A The Snake"
            };
            var xmlValue = testObject.Serialize();
            result = ServiceLogic.XmlToJson(xmlValue);
            var resultObj = JsonConvert.DeserializeObject<DeserializeContent>(result);
            Assert.AreEqual(testObject.XmlJsonProp1, resultObj.XMLJsonTester.XmlJsonProp1);
            Assert.AreEqual(testObject.XmlJsonProp2, resultObj.XMLJsonTester.XmlJsonProp2);
            Assert.AreEqual(testObject.XmlJsonProp3, resultObj.XMLJsonTester.XmlJsonProp3);
            Assert.AreEqual(testObject.XmlJsonProp4, resultObj.XMLJsonTester.XmlJsonProp4);
            Assert.AreEqual(testObject.XmlJsonProp5, resultObj.XMLJsonTester.XmlJsonProp5);
        }
    }
}
