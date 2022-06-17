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
    public class PaymentRepository : IPaymentRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection sqlCon = new SqlConnection(connectionString);
        public bool row;
        public DataTable findBillByMobile(string mobileNo)
        {
            DataTable dt = new DataTable();
            string query = "sp_findBillByMobile";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mobileNo", SqlDbType.NVarChar).Value = mobileNo;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        public DataTable SubmitTotall(string phnNo)
        {
            DataTable dt = new DataTable();
            string query = "sp_submitTotall";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mobileNumber", SqlDbType.NVarChar).Value = phnNo;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        public DataTable countTotall(string mobileNo)
        {
            DataTable dt = new DataTable();
            string query = "sp_countTotall";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mobile", SqlDbType.NVarChar).Value = mobileNo;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }
    }
}
