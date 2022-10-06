using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BussinessObject.model
{
    [Serializable]
    [XmlRoot("patient")]
    public class Patient
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string identityNumber { get; set; }
        public string address { get; set; }

        public Patient() { }
        public Patient(string id, string identityNumber, string fullName, string address)
        {
            this.id = id;
            this.identityNumber = identityNumber;
            this.fullName = fullName;
            this.address = address;
        }
          
    }
}
