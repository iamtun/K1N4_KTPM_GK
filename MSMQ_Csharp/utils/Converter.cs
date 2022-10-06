using MSMQ_Csharp.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSMQ_Csharp.utils
{
     class Converter
    {
        public static string Object2XML(Patient p)
        {
            string xml = "";
            XmlSerializer ser = new XmlSerializer(typeof(Patient));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.Serialize(ms, p);
                ms.Position = 0;
                xml = new StreamReader(ms).ReadToEnd();
            }
            return xml;
        }

        public static Patient Xml2Object(string xml)
        {
            using (var stringReader = new System.IO.StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(Patient));
                return serializer.Deserialize(stringReader) as Patient;
            }
        }
    }
}
