using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInformationSender
{
    public class DBConnection
    {
        mPatientDataContext context;

        public mPatientDataContext getConnection()
        {
            string sql = @"Data Source=DESKTOP-7A8D61I\SQLEXPRESS;Initial Catalog=patient_management;Persist Security Info=True;User ID=sa;Password=123456";

            context = new mPatientDataContext(sql)
            {
                CommandTimeout = 30000
            };
            context.Connection.Open();

            return context;
        }
    }
}
