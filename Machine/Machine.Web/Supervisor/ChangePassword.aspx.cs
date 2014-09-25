using System;

namespace Machine.Web.Supervisor
{
    public partial class ChangePassword : common.UserBasePage
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillProfile();
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

        private void FillProfile()
        {
            if (Session["UserId"] != null && Session["UserId"].ToString().Trim() != "")
            {
                int Userid = Convert.ToInt32(Session["UserId"].ToString());

                DAL.User u = BAL.BLUser.GetUserDetail(CommonUtil.con, Userid);
                tbName.Text = u.UserName;
 
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null && Session["UserId"].ToString().Trim() != "")
            {
                int Userid = Convert.ToInt32(Session["UserId"].ToString());
                if (tbOldPass.Text.Trim() != "" && tbNewPass.Text.Trim() != "" && (tbNewPass.Text.Trim() == tbNewCnfrmPass.Text.Trim()))
                {
                    int result = BAL.BLUser.UserChangePassword(CommonUtil.con, Userid, tbOldPass.Text.Trim(), tbNewPass.Text.Trim());
                   if(result >0 )
                       ShowError("Password changed successfully.", false);
                   else if (result == -1)
                       ShowError("Old Password is incorrect, Please try again.", true);
                   else
                       ShowError("Error occured, Please try again.", true);
                }
                else
                    ShowError("Please fill the required field.", true);
            }
            else
            {
                Response.Redirect("/Login.aspx", true);
            }
        } 
    }
}