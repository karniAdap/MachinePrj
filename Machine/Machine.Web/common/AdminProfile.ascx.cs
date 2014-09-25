using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Machine.Web.common
{
    public partial class AdminProfile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                if (Session["UserName"] != null && Session["UserName"].ToString().Trim() !="")
                {
                    ltUserName.Text = Session["UserName"].ToString();
                }
            }
        }
    }
}