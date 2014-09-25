using System;
using System.Web.UI.WebControls;
using Machine.BAL;
using Machine.DAL;
using System.Collections.Generic;

namespace Machine.Web.Admin
{
    public partial class AdminRole : AdminBasePage
    {
        protected override void OnPreRender(EventArgs e)
        {
            ViewState["PageRefresh"] = Session["PageRefresh"];
        }

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                ViewState["PageRefresh"] = Session["PageRefresh"] = Guid.NewGuid();
                FillGrid();
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

        private void FillGrid()
        {
            gvAdminRole.DataSource = .GetAdminRole(CommonUtil.con);
            gvAdminRole.DataBind();
        }

        protected void btnWeekenUpdate_Click(object sender, EventArgs e)
        {
            if (Session["PageRefresh"].ToString() == ViewState["PageRefresh"].ToString())
            {
                Session["PageRefresh"] = Guid.NewGuid();
            }
            else
            {
                FillGrid();
                return;
            }
            if (gvAdminRole.Rows.Count > 0)
            {
                DAL.Common.ExtNonQuery(CommonUtil.con, "Truncate Table AdminRole");
                for (int i = 0; i < gvAdminRole.Rows.Count; i++)
                {
                    bool IsAdmin = ((CheckBox)gvAdminRole.Rows[i].FindControl("chk")).Checked;
                    bool IsTrail = ((CheckBox)gvAdminRole.Rows[i].FindControl("chkTrail")).Checked;
                    int AdminId = Convert.ToInt32(gvAdminRole.DataKeys[i].Value);

                    if (IsAdmin)
                        DAL.Common.ExtNonQuery(CommonUtil.con, "insert into AdminRole (RoleId,AdminId) Values(1," + AdminId + ")");

                    if (IsTrail)
                        DAL.Common.ExtNonQuery(CommonUtil.con, "insert into AdminRole (RoleId,AdminId) Values(2," + AdminId + ")");
                }
                ShowError("Weekend updated successfully", false);
                FillGrid();
            }
        }
    }
}