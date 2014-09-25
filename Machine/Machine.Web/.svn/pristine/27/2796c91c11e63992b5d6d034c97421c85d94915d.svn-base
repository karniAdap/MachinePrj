using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Machine.Web.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public string strMenu { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
            }
        } 
        protected void btLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("AdminLogin.aspx", true);
        }
     }
}