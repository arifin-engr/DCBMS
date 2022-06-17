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
    public class TestSearchRepository : ITestSearchRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection sqlCon = new SqlConnection(connectionString);
        public bool row;
        public DataTable getReport(string fromDate, string toDate)
        {
            //DateTime fDate = Convert.ToDateTime(fromDate);
            //DateTime tDate = Convert.ToDateTime(toDate);
            DataTable dataTable = new DataTable();
            string query = "sp_findReportBydate";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@formDate", SqlDbType.Date).Value = fromDate;
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.Date).Value = toDate;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable);
            return dataTable;
        }

        public DataTable getUnpaidReport(string fromDate, string toDate)
        {
            //DateTime fDate = Convert.ToDateTime(fromDate);
            //DateTime tDate = Convert.ToDateTime(toDate);
            DataTable dataTable = new DataTable();
            string query = "sp_findUnpaidBydate";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@formDate", SqlDbType.Date).Value = fromDate;
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.Date).Value = toDate;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable);
            return dataTable;
        }
        public DataTable geTotall(string fromDate, string toDate)
        {
            //DateTime fDate = Convert.ToDateTime(fromDate);
            //DateTime tDate = Convert.ToDateTime(toDate);
            DataTable dataTable = new DataTable();
            string query = "sp_countTotallByDate";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@formDate", SqlDbType.Date).Value = fromDate;
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.Date).Value = toDate;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable);
            return dataTable;
        }
        public DataTable geUnpaidTotall(string fromDate, string toDate)
        {
            //DateTime fDate = Convert.ToDateTime(fromDate);
            //DateTime tDate = Convert.ToDateTime(toDate);
            DataTable dataTable = new DataTable();
            string query = "sp_countUnpaidTotallByDate";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@formDate", SqlDbType.Date).Value = fromDate;
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.Date).Value = toDate;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable);
            return dataTable;
        }

        //TestWise
        public DataTable getTypewiseReport(string fromDate, string toDate)
        {
            //DateTime fDate = Convert.ToDateTime(fromDate);
            //DateTime tDate = Convert.ToDateTime(toDate);
            DataTable dataTable = new DataTable();
            string query = "sp_findTypeWiseReportBydate";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@formDate", SqlDbType.Date).Value = fromDate;
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.Date).Value = toDate;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable); 
            return dataTable;
        }
        public DataTable geTypewiseTotall(string fromDate, string toDate)
        {
            //DateTime fDate = Convert.ToDateTime(fromDate);
            //DateTime tDate = Convert.ToDateTime(toDate);
            DataTable dataTable = new DataTable();
            string query = "sp_countTotallByDate";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@formDate", SqlDbType.Date).Value = fromDate;
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.Date).Value = toDate;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable);
            return dataTable;
        }
    }
}
