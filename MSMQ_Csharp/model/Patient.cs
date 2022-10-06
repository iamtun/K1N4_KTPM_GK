using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSMQ_Csharp.model
{
    [Serializable]
    [XmlRoot("patient")]
    public class Patient
    {
        public string id { get; set; }
        public string identityNumber { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }

       /* public Patient(String id, String identityNumber, String fullName, String address)
        {
            this.id = id;
            this.identityNumber = identityNumber;
            this.fullName = fullName;
            this.address = address;
        }

        public Patient()
        {
        }*/
    }
}
