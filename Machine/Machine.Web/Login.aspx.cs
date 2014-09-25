using System;
using System.Web;
using System.Web.UI.WebControls;

namespace Machine.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double dprice = 24.241;
            double dp = 24.24546;
            dp = Math.Round(dp, 2);
            dprice = Math.Round(dprice, 2);

            /* if (Request.IsSecureConnection == false)
             {
                 string strURL = "https://" + Request.Url.DnsSafeHost  + Request.RawUrl;
                 Response.Redirect(strURL);
             }*/
            if ((Session["UserId"] != null))
            {
                Session.Abandon();
                Session.Clear();
                System.Web.Security.FormsAuthentication.SignOut();

                Response.ClearHeaders();
                Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                Response.AddHeader("Pragma", "no-cache");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DAL.User user= Machine.BAL.BLUser.UserLogin(CommonUtil.con, tbName.Text.Trim(), tbPass.Text.Trim());
            if (user != null)
            {
              
                Session["UserId"] = user.UserId;
                Session["UserName"] = (user.FirstName + " " + user.LastName).Trim();
                Response.Redirect("/Supervisor/Default.aspx", true);
            }
            else
            {
                error_msg.Visible = true;
                error_msg1.InnerText = "Invalid Username/Password";
            }
        }
    }
}