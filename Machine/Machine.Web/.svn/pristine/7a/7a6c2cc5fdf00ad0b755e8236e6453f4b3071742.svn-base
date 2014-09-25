using System;

namespace Machine.Web.Supervisor
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserMenu"] != null && Convert.ToString(Session["UserMenu"]).Trim() != "")
                {
                    ltMenu.Text = Session["UserMenu"].ToString();
                    divMenu.Visible = true;
                }
                else { divMenu.Visible = false; }
            }
        }
         
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();

            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");

            Response.Redirect("/Login.aspx", true);
        }
    }
}