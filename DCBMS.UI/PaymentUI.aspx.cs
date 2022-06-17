
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
    public partial class PaymentUI : System.Web.UI.Page
    {
        PaymentManager paymentManager = new PaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            string phoneNumber = "";
            string input = txt_mobile.Text;
            if (input.Length>10 && input.Length<15)
            {
                string firstThree = input.Substring(0, 3);
                if (firstThree == "+88")
                {
                    phoneNumber = txt_mobile.Text;
                    gv.DataSource = paymentManager.findBillByMobileNo(phoneNumber);
                }
                else
                {
                    phoneNumber = "+88";

                    phoneNumber += txt_mobile.Text;
                }
                gv.DataSource = paymentManager.findBillByMobileNo(phoneNumber);
                gv.DataBind();
                string totall = "";
                string status = "";
                foreach (DataRow dr in paymentManager.countTotall(phoneNumber).Rows)
                {
                    totall = dr["totall"].ToString();
                    
                }
                txt_totall.Text =totall;
                foreach (DataRow dr in paymentManager.findBillByMobileNo(phoneNumber).Rows)
                {
                   
                    status = dr["PaymentStatus"].ToString();
                }
                if (status=="Paid")
                {
                    lbl_totall.Text = "Payment Status: " + status;
                    lbl_totall.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lbl_totall.Text = "Payment Status: " + status;
                    lbl_totall.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lbl_message.Text = "Incorrect Mobile Number...!";
                lbl_message.ForeColor = System.Drawing.Color.Red;
            }
            
           
            
            
           
        }

        protected void btn_pay_Click(object sender, EventArgs e)
        {
            double totall = double.Parse(txt_totall.Text);
            double amount = double.Parse(txt_amount.Text);

            string phoneNumber = "";
            string input = txt_mobile.Text;
            DataTable dt = new DataTable();
            if (input.Length > 10 && input.Length < 15)
            {
                string firstThree = input.Substring(0, 3);
                if (firstThree == "+88")
                {
                    phoneNumber = txt_mobile.Text;


                    if (amount == totall)
                    {

                        dt = paymentManager.SubmitTotall(phoneNumber);

                    }
                    else
                    {
                        lbl_payMentMessage.Text = "Please Enter Totall Amount";
                        lbl_payMentMessage.ForeColor = System.Drawing.Color.Red;
                    }


                }
                else
                {
                    phoneNumber = "+88";

                    phoneNumber += txt_mobile.Text;
                    dt = paymentManager.SubmitTotall(phoneNumber);
                }

                gv2.DataSource = dt;
                gv2.DataBind();
                lbl_payMentMessage.Text = "Payment Successfully Complite...";
                lbl_payMentMessage.ForeColor = System.Drawing.Color.Green;


            }
            }
    }
}