using System;
using System.Web.UI.WebControls;
using Machine.BAL;
using Machine.DAL;
using System.Collections.Generic;
using System.Data;

namespace Machine.Web.Admin
{
    public partial class Settings : AdminBasePage
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
            DataSet Ds = DAL.Common.ExtDataset(CommonUtil.con, "Select Top 1 * from Settings");
            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                tbEmail.Text = Ds.Tables[0].Rows[0]["Email"].ToString();
                tbSMTP.Text = Ds.Tables[0].Rows[0]["SMTP"].ToString();
                tbPort.Text = Ds.Tables[0].Rows[0]["Port"].ToString();
                tbLabourRate.Text = Ds.Tables[0].Rows[0]["LabourRate"].ToString();
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
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

            if (Convert.ToInt32(DAL.Common.ExtScaler(CommonUtil.con, "Select Count('x') from Settings")) > 0)
                DAL.Common.ExtNonQuery(CommonUtil.con, "Update Settings Set Email='" + tbEmail.Text.Trim() + "', SMTP='" + tbSMTP.Text.Trim() + "', Port='" + tbPort.Text.Trim() + "', LabourRate='" + tbLabourRate.Text.Trim() + "'");
            else
                DAL.Common.ExtNonQuery(CommonUtil.con, "Insert into Settings (Email, SMTP, Port, LabourRate) Values('" + tbEmail.Text.Trim() + "', '" + tbSMTP.Text.Trim() + "', '" + tbPort.Text.Trim() + "', '" + tbLabourRate.Text.Trim() + "')");

            ShowError("Settings updated successfully", false);
            FillGrid();
        }
    }
}