using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Machine.Web.common
{
    public partial class AdminLogo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                readFile();
        }
        public void readFile()
        {
            string fPath = Server.MapPath("~/App_Data/AdminContent.txt");
            if (System.IO.File.Exists(fPath))
            {
                string[] str = System.IO.File.ReadAllLines(fPath);
                ltLogo.Text = str[0];
                imgLogo.Src = str[1];
            }
            else
                imgLogo.Src = "/images/noimage.png";
        }
    }
}