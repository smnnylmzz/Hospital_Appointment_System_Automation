using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Hospital_Management_and_Appointment_System_Automation
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=OSMAN\\SQLEXPRESS;Initial Catalog=HospitalProject;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
