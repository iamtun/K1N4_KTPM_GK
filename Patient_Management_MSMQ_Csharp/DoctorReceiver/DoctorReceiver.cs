using Apache.NMS;
using Apache.NMS.ActiveMQ.Commands;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BussinessObject.model;
using System.Collections;

namespace DoctorReceiver
{
    public partial class DoctorReceiver : Form
    {
        IConnection conn;
        ISession session;
        PatientDB Patient;
        MedicalExam Medical;

        List<Patient> patientList;

        public DoctorReceiver()
        {
            InitializeComponent();
            createConsumer();
           /* Patient = new Patient();
            Medical = new MedicalExam();*/
            patientList = new List<Patient>();
            loadPatientIdToListBox(patientList);
        }

        //comsumer listening message queue send from Sender
        public void createConsumer()
        {
            Console.WriteLine("Receiving ...");
            conn = ConnectApache.getConnection();
            session = conn.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue destination = new ActiveMQQueue("otgk");
            IMessageConsumer consumer = session.CreateConsumer(destination);
            consumer.Listener += Consumer_Listener;
        }

        // envent listening message ...
        private void Consumer_Listener(IMessage message)
        {
            if(message is ActiveMQTextMessage)
            {
                ActiveMQTextMessage objMessage = (ActiveMQTextMessage)message;
                Console.WriteLine("Receiver: " + objMessage.Text);
                
                Patient patient = XMLConverter<Patient>.xml2Object(objMessage.Text);
                //Patient.insertPatient(patient);
                patientList.Add(patient);
                lbPatients.Invoke(new Action(() => loadPatientIdToListBox(patientList)));
            }
        }

        //load data to list box
        private void loadPatientIdToListBox(IEnumerable<Patient> patients)
        {
            lbPatients.Items.Clear();
            foreach(Patient patient in patients)
            {
                lbPatients.Items.Add(patient.id);
            }
        }

        private void lbPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPatients.SelectedItems.Count > 0)
            {
                int id = lbPatients.SelectedIndex;
                Patient patient = patientList[id];
                if (patient != null)
                {
                    loadInfoToInput(patient);
                }
                else
                {
                    MessageBox.Show("Patient invalid!");
                }
            }
        }

        //load info patient then click 
        private void loadInfoToInput(Patient patient)
        {
            txtPatientID.Text = patient.id;
            txtIdentityNumber.Text = patient.identityNumber;
            txtFullName.Text = patient.fullName;
            rtxAddress.Text = patient.address;
        }

        private void DoctorReceiver_FormClosing(object sender, FormClosingEventArgs e)
        {
            //exit
            session.Close();
            conn.Close();
        }


        private void btnCallExam_Click(object sender, EventArgs e)
        {
            string id = lbPatients.SelectedItem.ToString();
            Medical.insertateMedicalExamByPatientId(id);
            loadPatientIdToListBox(patientList);
            btnCallExam.Enabled = false;
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            string id = txtPatientID.Text;
            string infoExam = rtxNote.Text;
            bool isTrue = Medical.updateDateMedicalExamByPatientId(id, infoExam);
            if (isTrue)
            {
                clearInput();
                btnCallExam.Enabled = true;
            }
                
        }

        private void clearInput()
        {
            txtFullName.Clear();
            txtIdentityNumber.Clear();
            txtPatientID.Clear();
            rtxAddress.Clear();
            rtxNote.Clear();
        }
    }
}
