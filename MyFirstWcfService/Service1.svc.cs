using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyFirstWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public EducationalInfo GetEducationalDetails(string region)
        {
            EducationalInfo info = null;
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-M1LH9004\\SQLEXPRESS; Initial Catalog=Educational; Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT [BetchCollege],[MedicalCollege],[MbaCollege] FROM[Educational].[dbo].[EducationalInfo] where region = @region", connection);
            command.Parameters.AddWithValue("@region",region);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                info = new EducationalInfo();
                info.BetchCollege = reader.GetInt32(0);
                info.MedicalCollege = reader.GetInt32(1);
                info.MbaCollege = reader.GetInt32(2);


            }
            connection.Close();
            return info;

            
        }
    }
}
