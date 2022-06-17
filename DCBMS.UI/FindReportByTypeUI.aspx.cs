using DCBMS.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBMS.UI.AllDataSet;
using DCBMS.UI.Report;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using System.Data.SqlClient;

namespace DCBMS.UI
{
    public partial class FindReportByTypeUI : System.Web.UI.Page
    {
        TestSearchManager testSearchManager = new TestSearchManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            var fromDate = txt_fromDate.Text;
            var toDate = txt_todate.Text;

            gv2.DataSource = testSearchManager.getTypewiseReport(fromDate, toDate);
            gv2.DataBind();
            string totall = "";
            DataTable totallAmount = testSearchManager.getTypewiseTotalByDate(fromDate, toDate);
            foreach (DataRow dr in totallAmount.Rows)
            {
                totall = dr["totall"].ToString();
            }
            txt_totall.Text = totall;
        }

        protected void btn_Print_Click(object sender, EventArgs e)
        {
             string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            var fromDate = txt_fromDate.Text;
            var toDate = txt_todate.Text;
            DataSet ds = new DataSet();

            string query = "sp_findTypeWiseReportBydate";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@formDate", SqlDbType.Date).Value = fromDate;
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.Date).Value = toDate;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);

            DataTable dt = new DataTable();


            //dt = testSearchManager.getTypewiseReport(fromDate, toDate);
            rpt_ReportTestType report1 = new rpt_ReportTestType();
            report1.Database.Tables["TotallTypeReport"].SetDataSource(ds.Tables[0]);


          


            report1.Database.Tables["totall"].SetDataSource(ds.Tables[1]);
            //report1.SetDataSource(dt);
            string reportFilePath = Server.MapPath("rpt_TotallTypeWiseReport.rpt");
            ReportDocument reportDocument = new ReportDocument();
           
            _crv.ReportSource = report1;
            report1.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "My Report");
        }
    }
}