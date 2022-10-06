using PatientInformationSender;
using System;
using System.Data.Common;
using System.Linq;

namespace BussinessObject.model
{
    public class MedicalExam : DBConnection
    {
        mPatientDataContext context;
        public MedicalExam()
        {
            context = getConnection();
        }

        public bool insertateMedicalExamByPatientId(string _id)
        {
            medical_examination medical = createMedicalExam(_id);
            using (DbTransaction br = context.Connection.BeginTransaction())
            {
                try
                {
                    context.Transaction = br;
                    context.medical_examinations.InsertOnSubmit(medical);
                    context.SubmitChanges();
                    context.Transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    context.Transaction.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

        private medical_examination createMedicalExam(string id)
        {
            medical_examination medical = new medical_examination();
            medical.doctor_id = "1001";
            medical.patient_id = id;
            medical.exam_date = DateTime.Now;

            return medical;
        }

        public bool updateDateMedicalExamByPatientId(string _id, string infoExam)
        {
            using (DbTransaction br = context.Connection.BeginTransaction())
            {
                try
                {
                    context.Transaction = br;
                    medical_examination medical = (from n in context.medical_examinations
                                                   where n.patient_id.Equals(_id)
                                                   select n).First();
                    medical.note = infoExam;
                    context.SubmitChanges();
                    context.Transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    context.Transaction.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }

    }
}
