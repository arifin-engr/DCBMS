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
    public partial class TestTypeUI : System.Web.UI.Page
    {
       
        TestTypeManager testTypeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            gv.DataSource = testTypeManager.getAllTypeName();
            gv.DataBind();

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            TestType testType = new TestType();
            try
            {
                testType.TypeName = txt_TypeName.Text;
               bool ischeck=  testTypeManager.checkTypeNameIsExistorNot(testType);
                if (ischeck==true)
                {
                    testTypeManager.Add(testType);
                }
                else
                {
                    lbl_OprartionMessage.Text = "This Type Name  Already Exists";
                    lbl_OprartionMessage.ForeColor = System.Drawing.Color.Red;
                }
                
                
               
            }
            catch (Exception ex)
            {
                lbl_OprartionMessage.Text = ex.Message;
                lbl_OprartionMessage.ForeColor = System.Drawing.Color.Green;
                //System.Threading.Thread.Sleep(5000);
                //lbl_OprartionMessage.Text = "";

            }
            clear();

        }
       

        void clear()
        {
            txt_TypeName.Text = "";
        }
       
    }
}