using BussinessObject.model;
using System;
using System.IO;
using System.Xml.Serialization;

namespace BussinessObject
{
    public class XMLConverter<T>
    {
        public static string object2XML(T p)
        {
            string xml = "";
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.Serialize(ms, p);
                ms.Position = 0;
                xml = new StreamReader(ms).ReadToEnd();
            }
            return xml;
        }

        public static Patient xml2Object(string xml)
        {
            var stringReader = new System.IO.StringReader(xml);
            var serializer = new XmlSerializer(typeof(Patient));
            return serializer.Deserialize(stringReader) as Patient;
        }

    }
}
