using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sentio.BusinessLogic
{
    public static class ServiceLogic
    {
        public static int Fibonacci(int n)
        {
            int firstnumber = 0, secondnumber = 1, result = 0;

            if (100 < n || 1 > n) return -1; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   


            for (int i = 2; i <= n; i++)
            {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }

            return result;
        }

        public static string XmlToJson(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                return JsonConvert.SerializeXmlNode(doc);
            }
            catch (XmlException ex)
            {
                return "Bad Xml format";
            }
        }
    }
}
