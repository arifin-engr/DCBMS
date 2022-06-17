using DCBMS.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DCBMS.UI
{
    public partial class FindUnPiadBillUI : System.Web.UI.Page
    {
        TestSearchManager testSearchManager = new TestSearchManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            var fromDate = txt_fromDate.Text;
            var toDate = txt_todate.Text;

            gv2.DataSource = testSearchManager.getUnpaidTestReport(fromDate, toDate);
            gv2.DataBind();
            string totall = "";
            DataTable totallAmount = testSearchManager.getUnpaidTotalByDate(fromDate, toDate);
            foreach (DataRow dr in totallAmount.Rows)
            {
                totall = dr["totall"].ToString();
            }
            txt_totall.Text = totall;
        }
    }
}