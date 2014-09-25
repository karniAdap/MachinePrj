using System;
using System.Web.UI.WebControls;
using Machine.BAL;
using Machine.DAL;
using System.Collections.Generic;

namespace Machine.Web.Admin
{
    public partial class PlantHirMachine : AdminBasePage
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
            tbName.Text = tbValue.Text = "";
            btnAdd.Visible = index == 0 ? true : false;
            headerText.Text = IsEdit == true ? "Create Machine" : "Edit Machine";
            hid.Value = "0";
            error_msg.Visible = false;
            success_msg.Visible = false;

            tbName.ReadOnly = false;
            tbName.Focus();
        }

        private void FillGrid()
        {
           // var lst = BLMachine.GetList(CommonUtil.con, ddlEqType.SelectedValue.ToString(), tbSearch.Text.Trim()).ToList();
            gvMachines.DataSource = null;
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
             //   DAL.Machine Machine = BLMachine.GetDetail(CommonUtil.con, MachineId);
                //if (Machine != null)
                //{
                //    showView(false, 1);
                //    hid.Value = MachineId.ToString();
                //    tbName.Text = Machine.Name;
                //    tbValue.Text = Machine.Value;

                //    tbName.ReadOnly = true;
                //}
            }
            else if (e.CommandName == "MachineDelete")
            {
                int MachineId = Convert.ToInt32(gvMachines.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                //int sucess_delete = Convert.ToInt32(BLMachine.Delete(CommonUtil.con, MachineId));
                //if (sucess_delete > 0)
                //{
                //    FillGrid();
                //    ShowError("Machine deleted successfully.", false);
                //}
                //else
                //{
                //    ShowError("To delete user, please deselect assigned group.", true);
                //}
                //BLMachine.GetDetail(CommonUtil.con, MachineId);
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
            if (tbName.Text.Trim() != "")
            {
                if (tbValue.Text.Trim() != "")
                {
                    if (Convert.ToInt32(hid.Value) > 0)
                    {
                        //if (!BLMachine.CheckExist(CommonUtil.con, tbName.Text.Trim(), Convert.ToInt32(hid.Value)))
                        //{
                        //    int user_sucess = BLMachine.Edit(CommonUtil.con, Convert.ToInt32(hid.Value), tbName.Text.Trim(), tbValue.Text.Trim(), ddlEqType.SelectedValue.ToString());
                        //    if (user_sucess > 0)
                        //    {
                        //        showView(false, 0);
                        //        FillGrid();
                        //        ShowError("Machine Updated Successfully", false);
                        //    }
                        //}
                        //else { ShowError("Machine Name Already Exists.", true); }

                    }
                    else
                    {
                        //if (BLMachine.CheckExist(CommonUtil.con, tbName.Text.Trim(), 0))
                        //{
                        //    ShowError("Machine Name Already Exists!!", true);
                        //}
                        //else
                        //{
                        //    int user_sucess1 = BLMachine.Edit(CommonUtil.con, Convert.ToInt32(hid.Value), tbName.Text.Trim(), tbValue.Text.Trim(), ddlEqType.SelectedValue.ToString());
                        //    if (user_sucess1 > 0)
                        //    {
                        //        showView(false, 0);
                        //        FillGrid();
                        //        ShowError(" Machine Created Successfully ", false);
                        //    }
                        //}
                    }
                }
                else { ShowError("Value Required", true); }
            }
            else { ShowError("Machine Name Required", true); }
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
               // DAL.Machine s = e.Row.DataItem as DAL.Machine;
             //   e.Row.Cells[3].Text = s.CreateDate.ToString("MMM dd yyyy");
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