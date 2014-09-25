using System;

namespace Machine.Web.Supervisor
{
    public partial class MyProfile : common.UserBasePage
    {   
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                FillProfile();
            }
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
                tbEmail.Text = u.Email;
                tbLastName.Text = u.LastName;
                tbFirstName.Text = u.FirstName;
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null && Session["UserId"].ToString().Trim() != "")
            {
                int Userid = Convert.ToInt32(Session["UserId"].ToString());
                if (tbEmail.Text.Trim() == "" || tbFirstName.Text.Trim() == "")
                {
                    ShowError("Please fill the required fields", true);
                    return;
                }

                if (BAL.BLUser.CheckEMail(CommonUtil.con, tbEmail.Text.Trim(), Userid) > 0)
                {
                    ShowError("Duplicate email!!", true);
                    return;
                }

                //if (BAL.BLUser.UserAddEdit(CommonUtil.con, Userid, "", "", tbFirstName.Text.Trim(), tbLastName.Text.Trim(), tbEmail.Text.Trim(), Convert.ToBoolean(dd) > 0)
                //{
                //    Session["UserName"] = (tbFirstName.Text.Trim()+ " " + tbLastName.Text.Trim()).Trim();
                //    ShowError("Profile updated successfully.", false);
                //}
                //else
                //    ShowError("Error occured, Please try again.", true);
            }
            else
                Response.Redirect("Login.aspx", true);
        }
    }
}