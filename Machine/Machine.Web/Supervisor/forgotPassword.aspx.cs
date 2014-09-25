using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Machine.Web.Supervisor
{
    public partial class forgotPassword : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void ShowError(string Msg, bool IsError)
        {
            if (IsError)
            {
                error_msg.Visible = true;
                error_msg1.InnerText = Msg;
                success_msg.Visible = false;
            }
            else
            {
                success_msg.Visible = true;
                success_msg1.InnerText = Msg;
                error_msg.Visible = false;

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (TxtEmail.Text.Trim() != "")
                {
                    if (txtBoxMsg.Text.Trim() != "")
                    {
                        int mail_check = Machine.BAL.BLUser.ForgotPwdCheckEmail(CommonUtil.con, TxtEmail.Text.Trim());
                        if (mail_check == 1)
                        {
                            ShowError("Email Not Exist", true);
                        }
                        else if (mail_check == 2)
                        {
                            ShowError("Password Reset Request Already Sent", true);
                        }
                        else if (mail_check == 0)
                        {
                            int sucessAdd = Machine.BAL.BLUser.ForgotPasswordAdd(CommonUtil.con, TxtEmail.Text.Trim(), txtBoxMsg.Text.Trim());
                            if (sucessAdd > 0)
                            {
                                ShowError("Password Request Sent Successfully", false);
                            }
                            }
                        }
                    }
                    else { ShowError("Message Required", true); }
                }
                else { ShowError("Email Required", true); }
            }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Supervisor/Default.aspx");
        }
        }
    
}