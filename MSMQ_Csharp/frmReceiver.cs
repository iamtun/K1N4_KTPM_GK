using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using MSMQ_Csharp.model;
using MSMQ_Csharp.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMQ_Csharp
{
    public partial class frmReceiver : Form
    {
        private IConnection conn;
        private ISession session;
        private List<Patient> patients;

        public frmReceiver()
        {
            InitializeComponent();
            patients = new List<Patient>();
            createConsumer();
        }

        private IConnection GetConnection()
        {
            Console.WriteLine("Connecting ...");
            IConnectionFactory connectionFactory = new ConnectionFactory("tcp://localhost:61616");
            IConnection conn = connectionFactory.CreateConnection("admin", "admin");
            conn.Start();
            return conn;

        }

        public void createConsumer()
        {
            //MessageBox.Show("Receiving ...");
            conn = GetConnection();
            session = conn.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue destination = new ActiveMQQueue("otgk");
            IMessageConsumer consumer = session.CreateConsumer(destination);
            consumer.Listener += Consumer_Listener;
        }

        private void Consumer_Listener(IMessage message)
        {
            if (message is ActiveMQTextMessage)
            {
                ActiveMQTextMessage objMessage = (ActiveMQTextMessage)message;
                MessageBox.Show("Receiver: " + objMessage.Text);
                Patient patient = Converter.Xml2Object(objMessage.Text);
                patients.Add(patient);
                lstPatients.Invoke(new Action(() => loadPatientIdToListBox(patients)));
            }
        }

        private void loadPatientIdToListBox(List<Patient> patients)
        {
            lstPatients.Items.Clear();
            foreach (Patient patient in patients)
            {
                lstPatients.Items.Add(patient.id);
            }
        }

        private void lstPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstPatients.SelectedIndex;
            LoadPatientToInput(patients[index]);
        }

        private void LoadPatientToInput(Patient patient)
        {
            txtId.Text = patient.id;
            txtName.Text = patient.fullName;
            txtCmnd.Text = patient.identityNumber;
            rtbAddress.Text = patient.address;
        }
    }


}
