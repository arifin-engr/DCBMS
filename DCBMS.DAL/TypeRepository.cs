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
    public class TypeRepository : ITypeRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection sqlCon = new SqlConnection(connectionString);

        public void Add(TestType testType)
        {
            string query = "sp_addTestType";
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@typeName", SqlDbType.NVarChar).Value = testType.TypeName;
               
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

        public bool checkTypeNameIsExistorNot(TestType testType)
        {
            
            string query = "sp_checkTypeName";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@typeName", SqlDbType.NVarChar).Value = testType.TypeName;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            sda.Fill(dt);

            
            if (dt.Rows.Count>0)
            {
               return false;
            }
            else
            {
              return  true;

            }
          
        }

        public DataTable getAll()
        {
            string query = "sp_getAll";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public DataTable getAllTypeName()
        {
            string query = "sp_getAllTypeName";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}
