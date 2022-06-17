using DCBMS.BL;
using DCBMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DCBMS.UI
{
    public partial class TestEntryUI : System.Web.UI.Page
    {
        TestSetupManager testSetup = new TestSetupManager();
        TestEntryManager entryManager = new TestEntryManager();
       DataTable dt=new DataTable();
        DataTable dataTable=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            gv2.Visible = false;
            if (!Page.IsPostBack)
            {
                ddl_test.DataSource = testSetup.getAll();
                ddl_test.DataTextField = "TestName";
                ddl_test.DataValueField = "TestSetupId";
                ddl_test.DataBind();
                ListItem listItem = new ListItem("--select--", "-1");
                ddl_test.Items.Insert(0, listItem);
                
                if (ViewState["Records"] == null)
                {

                    dt.Columns.Add("Test");
                    dt.Columns.Add("Fee");

                    ViewState["Records"] = dt;
                }
                if (ViewState["RecordList"] == null)
                {
                    dataTable.Columns.Add("PatientName");
                    dataTable.Columns.Add("DOB");
                    dataTable.Columns.Add("MobileNo");
                    dataTable.Columns.Add("TestId");
                    dataTable.Columns.Add("Fee");
                    dataTable.Columns.Add("EntryDate");

                    ViewState["RecordList"] = dataTable;
                }



            }


        }
        

        protected void ddl_test_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_test.SelectedIndex==0)
            {

            }
            else
            {
                
                int TestSetupId = Convert.ToInt32(ddl_test.SelectedItem.Value);
                foreach (DataRow dr in entryManager.getFeeByTestId(TestSetupId).Rows)
                {
                    txt_Fee.Text = dr["fee"].ToString();
                }
               

            }
            

        }

        //DataTable gett()
        //{
        //    DataTable dataTable = new DataTable();
        //    dataTable = (DataTable)ViewState["RecordList"];
        //    DateTime entryDate = DateTime.Today;
        //    dataTable.Rows.Add(txt_PatientName.Text, txt_dob.Text, txt_mobile.Text, ddl_test.SelectedValue, txt_Fee.Text, entryDate);

        //    gv2.DataSource = dataTable;
        //    gv2.DataBind();
        //    return dataTable;
        //}
        protected void btn_submit_Click(object sender, EventArgs e)
        {

            dt = (DataTable)ViewState["Records"];
            string item = ddl_test.SelectedItem.ToString().ToUpper();

            var a = dt.Select().ToList();
            bool exists = dt.Select().ToList().Exists(row => row["Test"].ToString().ToUpper() == item);
            if (exists==false)
            {
                dt.Rows.Add(ddl_test.SelectedItem, txt_Fee.Text);
                gv.DataSource = dt;
                gv.DataBind();
            }
            else
            {
                lbl_operationMessase.Text = "This Already Added";
                lbl_operationMessase.ForeColor = System.Drawing.Color.Red;
            }
            
            //DataTable dt = new DataTable();
            // if (ViewState["Records"] == null)
            //     dt = entryManager.getTestinfo(ddl_test.SelectedValue);

            
            int totall = 0;
            int fee = Int32.Parse(txt_Fee.Text);
            if (txt_totall.Text=="")
            {
                totall = fee;
            }
            //totall= totall+ Int32.Parse(txt_totall.Text);
            else
            {
                int nextTotall = Int32.Parse(txt_totall.Text);
                nextTotall += fee;
                totall = nextTotall;
            }
            txt_totall.Text = totall.ToString();
            //gett();





            //gv.DataSource= entryManager
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            entryManager.Add(TestEntry());
            clear();

        }

        public List<TestRequestEntry> TestEntry()
        {
            List<TestRequestEntry> testList = new List<TestRequestEntry>();

            TestRequestEntry testRequestEntry=null;
            DataTable dt =new DataTable();
            
            try
            {

               //dt = gett();
                dt = dt.DefaultView.ToTable(true, "PatientName", "DOB", "MobileNo", "TestId", "Fee", "EntryDate");
                foreach (DataRow dr in dt.Rows)
                {
                    testRequestEntry = new TestRequestEntry();
                    testRequestEntry.PatientName = dr["PatientName"].ToString();
                    testRequestEntry.DOB = String.IsNullOrEmpty(dr["DOB"].ToString()) ? DateTime.Parse("1/1/1990") : Convert.ToDateTime(dr["DOB"].ToString());
                    testRequestEntry.MobileNo = dr["MobileNo"].ToString();
                    testRequestEntry.TestId = String.IsNullOrEmpty(dr["TestId"].ToString()) ? 0 : Int32.Parse(dr["TestId"].ToString());
                    testRequestEntry.Fee = String.IsNullOrEmpty(dr["Fee"].ToString()) ? 0 : Int32.Parse(dr["Fee"].ToString());
                    testRequestEntry.EntryDate = String.IsNullOrEmpty(dr["EntryDate"].ToString()) ? DateTime.Parse("1/1/1990") : Convert.ToDateTime(dr["EntryDate"].ToString());

                    testList.Add(testRequestEntry);
                }
            }
            catch (Exception)
            {

                
            }
           


            return testList;
        }
        void clear()
        {
            txt_PatientName.Text = "";
            txt_mobile.Text = "";
            txt_totall.Text = "";
            txt_Fee.Text = "";
            txt_dob.Text = "";
            
        }
    }
}