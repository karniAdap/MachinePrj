using System;
using Machine.BAL;

namespace Machine.Web.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserName"] != null))
            {
                Session.Abandon();
                Session.Clear();
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() != "")
            {
                if (tbPass.Text.Trim() != "")
                {
                    DAL.User Admin = BLUser.UserLogin(CommonUtil.con, tbName.Text.Trim(), tbPass.Text.Trim());
                    if (Admin != null && Admin.IsAdmin)
                    {
                        Session["AdminId"] = Admin.UserId;
                        Response.Redirect("/Admin/Default.aspx", true);
                    }
                    else
                    {
                        error_msg.Visible = true;
                        error_msg.InnerText = "Invalid Username/Password";
                    }
                }
                else
                {
                    error_msg.Visible = true;
                    error_msg.InnerText = "Password Required";
                }
            }
            else
            { 
                error_msg.Visible = true;
                error_msg.InnerText = "Username Required";
            }
        }
    }
}