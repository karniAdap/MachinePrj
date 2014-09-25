using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Machine.Web.Admin
{
    public class AdminBasePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (Session["AdminId"] != null && Convert.ToInt32(Session["AdminId"]) > 0)
            {
                DAL.User admin = BAL.BLUser.GetUserDetail(CommonUtil.con, Convert.ToInt32(Session["AdminId"]));

                string fullName = (admin.FirstName + " " + admin.LastName).Trim();
                Session["UserName"] = fullName == "" ? admin.Email : fullName;

                //DataSet ds = DAL.Common.ExtDataset(CommonUtil.con, "Select RoleId from AdminRole where AdminId= " + admin.AdminId);
                //bool IsAdmin = false, IsTrail = false;
                //if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow dr in ds.Tables[0].Rows)
                //    {
                //        if (Convert.ToInt16(dr["RoleId"].ToString()) == 1)
                //            IsAdmin = true;
                //        if (Convert.ToInt16(dr["RoleId"].ToString()) == 2)
                //            IsTrail = true;
                //    }
                //}
                List<string> lstPages = new List<string>();
                lstPages.Add("AdminChangePassword.aspx");
                lstPages.Add("Default.aspx");
                lstPages.Add("Equipment.aspx");
                lstPages.Add("Users.aspx");
                lstPages.Add("Settings.aspx");


                //StringBuilder sb = new StringBuilder();
                //sb.Append(" <li><a href=\"#\">Admin Users </a><ul>" +
                //       "<li><a href=\"ManageAdmins.aspx\">Manage Admins</a></li>" +
                //      "<li><a href=\"AdminRole.aspx\">AdminRole</a></li></ul> </li>");

                //if (admin.AdminId == 1)
                //{
                //    //IsAdmin = IsTrail = true;
                //    sb.Append(" <li><a href=\"#\">Admin Users </a><ul>" +
                //         "<li><a href=\"ManageAdmins.aspx\">Manage Admins</a></li>" +
                //        "<li><a href=\"AdminRole.aspx\">AdminRole</a></li></ul> </li>");

                //    lstPages.Add("ManageAdmins.aspx");
                //    lstPages.Add("AdminRole.aspx");
                //}
                //if (IsAdmin)
                //{
                //    sb.Append("<li><a href=\"#\">Manage</a><ul>" +
                //                    "<li><a href=\"Users.aspx\">Users</a></li>" +
                //                    "<li><a href=\"Group.aspx\">Groups</a></li>" +
                //                    "<li><a href=\"Weekend.aspx\">Weekend</a></li>" +
                //                    "<li><a href=\"CatActive.aspx\">Update Category</a></li>" +
                //                    "<li><a href=\"ManageChart.aspx\">Manage Graph</a></li></ul></li>");

                //    lstPages.Add("Users.aspx");
                //    lstPages.Add("Group.aspx");
                //    lstPages.Add("Weekend.aspx");
                //    lstPages.Add("CatActive.aspx");
                //    lstPages.Add("ManageChart.aspx");
                //}
                //if (IsTrail)
                //{
                //    sb.Append("<li><a href=\"RptTrail.aspx\">Report</a><ul>" +
                //        "<li><a href=\"TrailUser.aspx\">Audit Trail User</a></li>" +
                //        "<li><a href=\"RptTrail.aspx\">Audit Trail Report</a></li></ul></li>");

                //    lstPages.Add("RptTrail.aspx");
                //    lstPages.Add("TrailUser.aspx");
                //}
              //  Session["strMenu"] = sb.ToString();

                string strUrl = this.Page.Request.Url.AbsolutePath.Replace("/Admin/", "");
                if (!lstPages.Contains(strUrl))
                {
                    Response.Redirect("~/Admin/Default.aspx", true);
                }
            }
            else
                Response.Redirect("AdminLogin.aspx", true);

            // base.OnPreInit(e); 
        }
    }
}