using System;
using System.Web.UI.WebControls;
using Machine.BAL;

namespace Machine.Web.Admin
{
    public partial class PlantHireMachine : AdminBasePage
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

        private void showView(bool IsEdit, int index)
        {
            mvMachine.ActiveViewIndex = index;
            tbHireDate.Text = tbDocketNo.Text = tbStartHour.Text = tbFinishHour.Text = tbWet.Text = tbNett.Text = "";
            ddlPlant.SelectedIndex = 0;
            btnAdd.Visible = index == 0 ? true : false;
            headerText.Text = IsEdit == true ? "Create Machine" : "Edit Machine";
            hid.Value = "0";
            error_msg.Visible = false;
            success_msg.Visible = false;
        }

        private void FillGrid()
        {
            ddlPlant.DataSource = BLEquipment.GetList(CommonUtil.con, "Plant");
            ddlPlant.DataTextField = "Name";
            ddlPlant.DataValueField = "EquipmentId";
            ddlPlant.DataBind();
            ddlPlant.Items.Insert(0, new ListItem("Select Plant", "0"));

            var lst = BLPlantHM.GetList(CommonUtil.con);
            gvMachines.DataSource = lst;
            gvMachines.DataBind();
        }

        protected void gvMachines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["PageRefresh"].ToString() == ViewState["PageRefresh"].ToString())
            {
                Session["PageRefresh"] = Guid.NewGuid();
            }
            else
            {
                FillGrid();
                showView(false, 0);
                return;
            }
            if (e.CommandName == "MachineEdit")
            {
                int MachineId = Convert.ToInt32(gvMachines.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                DAL.PlantHireMachine Machine = BLPlantHM.GetDetail(CommonUtil.con, MachineId);
                if (Machine != null)
                {
                    showView(false, 1);
                    hid.Value = MachineId.ToString();
                    tbHireDate.Text = Machine.HireDate.ToShortDateString();
                    tbDocketNo.Text = Machine.DocketNo.ToString();
                    tbStartHour.Text = Machine.StartHour.ToString();
                    tbFinishHour.Text = Machine.FinishHour.ToString();
                    ddlPlant.SelectedValue = Machine.PlantId.ToString();
                    tbWet.Text = Machine.Wet.ToString();
                    tbNett.Text = Machine.Nett.ToString();
                    //PlanHireMachineId HireDate DocketNo StartHour  FinishHour Hours Plant Wet Nett
                }
            }
            else if (e.CommandName == "MachineDelete")
            {
                int MachineId = Convert.ToInt32(gvMachines.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                int sucess_delete = Convert.ToInt32(BLPlantHM.Delete(CommonUtil.con, MachineId));
                if (sucess_delete > 0)
                {
                    FillGrid();
                    ShowError("Plant Hire Machine deleted successfully.", false);
                }
                else
                {
                    ShowError("Error occured, Please try again", true);
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Session["PageRefresh"].ToString() == ViewState["PageRefresh"].ToString())
            {
                Session["PageRefresh"] = Guid.NewGuid();
            }
            else
            {
                FillGrid();
                showView(false, 0);
                return;
            }
            showView(true, 1);
            hid.Value = "0";
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
                showView(false, 0);
                return;
            }

            double hours = 0;
            int user_sucess = BLPlantHM.Edit(CommonUtil.con, Convert.ToInt32(hid.Value), Convert.ToDateTime(tbHireDate.Text.Trim()), Convert.ToInt32(tbDocketNo.Text), Convert.ToDouble(tbStartHour.Text), Convert.ToDouble(tbFinishHour.Text), hours, Convert.ToInt32(ddlPlant.SelectedValue), Convert.ToDouble(tbWet.Text), Convert.ToDouble(tbNett.Text));
            if (user_sucess > 0)
            {
                showView(false, 0);
                FillGrid();
                ShowError((Convert.ToInt32(hid.Value) > 0) ? "Plant Hire Machine Updated Successfully" : "Plant Hire Machine Added Successfully", false);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session["PageRefresh"].ToString() == ViewState["PageRefresh"].ToString())
            {
                Session["PageRefresh"] = Guid.NewGuid();
            }
            else
            {
                FillGrid();
                showView(false, 0);
                return;
            }
            showView(false, 0);
            FillGrid();
        }
        protected void gvMachines_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DAL.PlantHireMachine s = e.Row.DataItem as DAL.PlantHireMachine;
                e.Row.Cells[0].Text = s.HireDate.ToString("MMM dd yyyy");
            }
        }


        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (Session["PageRefresh"].ToString() == ViewState["PageRefresh"].ToString())
            {
                Session["PageRefresh"] = Guid.NewGuid();
            }
            else
            {
                FillGrid();
                showView(false, 0);
                return;
            }
            showView(false, 0);
            FillGrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            FillGrid();
        }

        protected void gvMachines_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMachines.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        protected void ddlEqType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}