using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.Web.common
{
    public class UserBasePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (Session["UserId"] != null && Session["UserId"].ToString().Trim() != "" && Convert.ToInt32(Session["UserId"]) > 0)
            {
                    int Userid = Convert.ToInt32(Session["UserId"].ToString());
                    StringBuilder sb = new StringBuilder();
                    List<DAL.uReport> lst = BAL.BLUser.UserMenu(CommonUtil.con, Userid);
                    List<DAL.uReport> pLst = lst.Where(x => x.IsParent == true).ToList();
                    if (!pLst.Any(x => x.Name == "Trail Reports"))
                    {
                        if (Convert.ToInt32(DAL.Common.ExtScaler(CommonUtil.con, "Select Count('x') from UserTable where UserId=" + Userid)) > 0)
                            pLst.Add(new DAL.uReport(40, "Trail Reports", "Reports By Trail", "/Report/TrailReport.aspx", true, 0, true, 3, DateTime.Now));
                    }
                    List<string> lstPage = new List<string>();
                    lstPage.Add("/Supervisor/Default.aspx");
                    lstPage.Add("/Supervisor/MyProfile.aspx");
                    lstPage.Add("/Supervisor/ReportList.aspx");
                    lstPage.Add("/Supervisor/ChangePassword.aspx");

                    foreach (var item in pLst)
                    {
                        var chLst = lst.Where(x => x.Parent == item.ReportId).OrderBy(x => x.Index).ToList();
                        if (chLst.Count() > 0)
                        {
                            sb.Append("<li><a href='" + item.PageUrl + "'>" + item.Name + "</a><ul>");
                            foreach (var chrpt in chLst)
                            {
                                lstPage.Add(chrpt.PageUrl);
                                sb.Append("<li><a href='" + chrpt.PageUrl + "' >" + chrpt.Name + "</a></li>" + Environment.NewLine);
                            }
                            sb.Append("</ul>");
                        }
                        else
                        {
                            lstPage.Add(item.PageUrl);
                            sb.Append("<li ><a href='" + item.PageUrl + "'>" + item.Name + "</a>");
                        }
                        sb.Append("</li>");
                    }
                    if (sb.ToString() != "")
                        Session["UserMenu"] = sb.ToString();

                    string strUrl = this.Page.Request.Url.PathAndQuery;
                    if (!lstPage.Contains(strUrl))
                        Response.Redirect("~/Supervisor/Default.aspx", true);
                }
                else
                    Response.Redirect("/Login.aspx", true);
                //base.OnPreInit(e);
            
        }
    }
}