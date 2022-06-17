using DCBMS.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCBMS.DAL
{
    public class TestRequestEntryRepository : ITestRequestEntryRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection sqlCon = new SqlConnection(connectionString);
        public bool row;

        public void add(List<TestRequestEntry> testList)
        {
            TestRequestEntry testRequestEntry;
            foreach (var item in testList)
            {
                testRequestEntry = new TestRequestEntry();
                testRequestEntry.PatientName = item.PatientName;
                testRequestEntry.DOB = item.DOB.Date;
                testRequestEntry.MobileNo = item.MobileNo;
                testRequestEntry.TestId = item.TestId;
                testRequestEntry.Fee = item.Fee;
                testRequestEntry.EntryDate = item.EntryDate.Date;
                
                    string query = "sp_addTestRequest";
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@patientName", SqlDbType.NVarChar).Value = testRequestEntry.PatientName;
                    cmd.Parameters.AddWithValue("@dob", SqlDbType.Date).Value = testRequestEntry.DOB.Date;
                    cmd.Parameters.AddWithValue("@mobileNo", SqlDbType.NVarChar).Value = testRequestEntry.MobileNo;
                    cmd.Parameters.AddWithValue("@testId", SqlDbType.Int).Value = testRequestEntry.TestId;
                    cmd.Parameters.AddWithValue("@fee", SqlDbType.Decimal).Value = testRequestEntry.Fee;
                    cmd.Parameters.AddWithValue("@entryDate", SqlDbType.Date).Value = testRequestEntry.EntryDate.Date;

                sqlCon.Open();
                 row = cmd.ExecuteNonQuery() > 0;

                sqlCon.Close();

            }
            


           
        }

        public DataTable getTestinfo(int testId)
        {
            DataTable dt = new DataTable();
            string query = "sp_getTestNameFee";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@testId", SqlDbType.Int).Value = testId;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        public DataTable findFeeByeId(int id)
        {
            DataTable dt = new DataTable();
            string query = "sp_findFeeById";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            
            return dt;
        }

    }
}
