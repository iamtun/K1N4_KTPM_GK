using BussinessObject.model;
using PatientInformationSender;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BussinessObject
{
    public class PatientDB : DBConnection
    {
        mPatientDataContext context;
        MedicalExam Medical;
        public PatientDB()
        {
            context = getConnection();
            Medical = new MedicalExam();
        }

        public bool insertPatient(patient patient)
        {
            using(DbTransaction br = context.Connection.BeginTransaction())
            {
                try
                {
                    context.Transaction = br;
                    context.patients.InsertOnSubmit(patient);
                    context.SubmitChanges();
                    context.Transaction.Commit();
                    return true;
                }catch(Exception e)
                {
                    context.Transaction.Rollback();
                    throw new Exception(e.Message);
                }
            }

        }

        public IEnumerable<patient> getAllPatient()
        {
            IEnumerable<patient> patients = (from n in context.patients
                                             select n)
                                             .Where(p => (from a in context.medical_examinations select a)
                                                    .All(x => x.patient_id != p.id));

            return patients;
        }

        public patient getPatientById(string _id)
        {
            patient patient = (from n in context.patients
                               where n.id.Equals(_id)
                               select n).First();
            return patient;
        }
    }
}
