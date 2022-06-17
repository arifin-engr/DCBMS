using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCBMS.Model;

namespace DCBMS.DAL
{
    public class SetupRepository : ISetupRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection sqlCon = new SqlConnection(connectionString);
        public void Add(TestSetup testSetup)
        {
            string query = "sp_addTestSetup";
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@testName", SqlDbType.NVarChar).Value = testSetup.TestName;
                    sqlCommand.Parameters.AddWithValue("@fee", SqlDbType.Decimal).Value = testSetup.Fee;
                    sqlCommand.Parameters.AddWithValue("@testTypeId", SqlDbType.Int).Value = testSetup.TypeId;

                    sqlCon.Open();
                    bool row = sqlCommand.ExecuteNonQuery() > 0;

                    if (row == true)
                    {
                        throw new Exception("Successfully Saved.... ");
                    }
                    else
                    {
                        throw new Exception("Failed");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    sqlCon.Close();
                }
            
        }

        public bool checkedTestName(string testName)
        {
            string query = "sp_checkedTestName";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@testName", SqlDbType.NVarChar).Value = testName;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            string query = "sp_getllTestSetup";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
    }
}
