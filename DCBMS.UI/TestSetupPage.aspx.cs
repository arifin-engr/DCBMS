using DCBMS.BL;
using DCBMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DCBMS.UI
{
    public partial class TestSetupPage : System.Web.UI.Page
    {
        TestTypeManager testTypeManager = new TestTypeManager();
        TestSetupManager testSetupManager = new TestSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (! IsPostBack)
            {
                ddl_testType.DataSource = testTypeManager.getAll();
                ddl_testType.DataTextField = "TypeName";
                ddl_testType.DataValueField = "TypeId";
                ddl_testType.DataBind();
                ListItem listItem = new ListItem("---- select ----", "-1");
                ddl_testType.Items.Insert(0, listItem);
                
            }
            gv.DataSource = testSetupManager.getAll();
            gv.DataBind();
            
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            
            TestSetup testSetup = new TestSetup();
            try
            {
                testSetup.TestName = txt_TestName.Text;
                testSetup.Fee = Convert.ToDouble(txt_fee.Text);
                testSetup.TypeId = Int32.Parse(ddl_testType.SelectedValue);
               // testSetup.AddDate = DateTime.Now;
                bool isChecked = testSetupManager.testNameChecked(testSetup.TestName);
                if (isChecked == true)
                {
                    testSetupManager.Add(testSetup);
                    lbl_oprationMessage.Text = "Successfully Saved";
                    gv.DataSource = testSetupManager.getAll();
                    gv.DataBind();
                     clear();
                    // lbl_oprationMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lbl_oprationMessage.Text = "This Name Already Exsist";
                    lbl_oprationMessage.ForeColor = System.Drawing.Color.Red;

                }
            }
            catch (Exception ex)
            {
                 lbl_oprationMessage.Text = ex.Message;
                    lbl_oprationMessage.ForeColor = System.Drawing.Color.Green;
               
               


            }
           finally
            {
                clear();
            }
            gv.DataSource = testSetupManager.getAll();
            gv.DataBind();
            clear();
        }
       

        void clear()
        {
          txt_TestName.Text = "";
            txt_fee.Text = "";
            ListItem listItem = new ListItem("---- select ----", "-1");
            ddl_testType.Items.Insert(0, listItem);
        }
    }
}