using System;
using Machine.BAL;

namespace Machine.Web.Admin
{
    public partial class AdminChangePassword : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                if (!IsPostBack)
                    tbName.Text = (string)Session["UserName"];
            }
            else
            {
                Response.Redirect("~/Admin/AdminLogin.aspx", true);
            }
            tbOldPass.Focus();
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
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (tbOldPass.Text.Trim() != "")
            {
                if (tbNewPass.Text.Trim() != "")
                {
                    if (tbNewCnfrmPass.Text.Trim() != "")
                    {
                        if (tbNewPass.Text.Trim() == tbNewCnfrmPass.Text.Trim())
                        {
                            int sucees_chng = BLUser.UserChangePassword(CommonUtil.con,Convert.ToInt32(Session["AdminId"].ToString()), tbNewPass.Text.Trim(), tbOldPass.Text.Trim());
                            if (sucees_chng == 1)
                            {
                                ShowError("Password Updated Successfully", false);
                            }
                            else
                            {
                                ShowError("Old Password Not Correct", true);
                            }
                        }
                        else { ShowError("Password Not Match", true); }
                    }
                    else { ShowError("Confirm Password Required", true); }
                }
                else { ShowError("New Password Required", true); }
            }
            else { ShowError("Old Password Required", true); }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/Default.aspx", true);
        }
    }
}