using Apache.NMS;
using Apache.NMS.ActiveMQ.Commands;
using BussinessObject;
using System;
using System.Windows.Forms;

namespace PatientInformationSender
{
    public partial class frmPatientInfoSender : Form
    {
        
        public frmPatientInfoSender()
        {
            InitializeComponent();
        }

        //clear input after click button
        private void resetInput()
        {
            txtFullName.Clear();
            txtIdentityNumber.Clear();
            txtPatientID.Text = createID();
            rtxAddress.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sending ...");
            IConnection conn = ConnectApache.getConnection();
            ISession session = conn.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue destination = new ActiveMQQueue("phongkham");
            IMessageProducer producer = session.CreateProducer(destination);

            //create object from input
            patient patient = new patient();
            patient.id = txtPatientID.Text;
            patient.identity_number = txtIdentityNumber.Text;
            patient.full_name = txtFullName.Text;
            patient.address = rtxAddress.Text;

            //convert object to xml
            string xml = XMLConverter<patient>.object2XML(patient);
            Console.WriteLine(xml);

            //create message and send
            IMessage msg = new ActiveMQTextMessage(xml);
            producer.Send(msg);

            //clear input
            resetInput();

        }

        private void frmPatientInfoSender_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmPatientInfoSender_Load(object sender, EventArgs e)
        {
            txtPatientID.Text = createID();
        }

        private string createID()
        {
            string[] now = DateTime.Now.ToString("dd/MM/yyyy").Split(' ')[0].Split('/');
            string id = "";
            for(int i = now.Length - 1; i >= 0; i--)
            {
                id += now[i];
            }

            return id + "_";
        }
    }
}
