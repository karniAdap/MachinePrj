using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Machine.Web.common
{
    public partial class UserProfile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Userid = 0;
                if (Session["UserId"] != null && int.TryParse(Session["UserId"].ToString(), out Userid) && Convert.ToInt32(Session["UserId"].ToString()) > 0)
                {
                    ltUserName.Text = Session["UserName"].ToString();
                }
            }
        }
    }
}