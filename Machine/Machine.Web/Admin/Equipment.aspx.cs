using System;
using System.Linq;
using System.Web.UI.WebControls;
using Machine.BAL;
using Machine.DAL;

namespace Machine.Web.Admin
{
    public partial class Equipment : AdminBasePage
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
            mvEquipment.ActiveViewIndex = index;
            tbName.Text = tbValue.Text = ""; 
            btnAdd.Visible = index == 0 ? true : false;
            headerText.Text = IsEdit == true ? "Create Equipment" : "Edit Equipment";
            hid.Value = "0";
            error_msg.Visible = false;
            success_msg.Visible = false;

            tbName.ReadOnly = false;
            tbName.Focus();
        }

        private void FillGrid()
        {
            var lst = BLEquipment.GetList(CommonUtil.con, ddlEqType.SelectedValue.ToString(), tbSearch.Text.Trim()).ToList();
            gvEquipments.DataSource = lst;
            gvEquipments.DataBind();
        }

        protected void gvEquipments_RowCommand(object sender, GridViewCommandEventArgs e)
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
            if (e.CommandName == "EquipmentEdit")
            {
                int EquipmentId = Convert.ToInt32(gvEquipments.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                DAL.Equipment Equipment = BLEquipment.GetDetail(CommonUtil.con, EquipmentId);
                if (Equipment != null)
                {
                    showView(false, 1);
                    hid.Value = EquipmentId.ToString();
                    tbName.Text = Equipment.Name;
                    tbValue.Text = Equipment.Value;

                    tbName.ReadOnly = true;
                }
            }
            else if (e.CommandName == "EquipmentDelete")
            {
                int EquipmentId = Convert.ToInt32(gvEquipments.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                int sucess_delete = Convert.ToInt32(BLEquipment.Delete(CommonUtil.con, EquipmentId));
                if (sucess_delete > 0)
                {
                    FillGrid();
                    ShowError("Equipment deleted successfully.", false);
                }
                else
                {
                    ShowError("To delete user, please deselect assigned group.", true);
                }
                BLEquipment.GetDetail(CommonUtil.con, EquipmentId);
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
                        if (!BLEquipment.CheckExist(CommonUtil.con, tbName.Text.Trim(), Convert.ToInt32(hid.Value)))
                        {
                            int user_sucess = BLEquipment.Edit(CommonUtil.con, Convert.ToInt32(hid.Value), tbName.Text.Trim(), tbValue.Text.Trim(), ddlEqType.SelectedValue.ToString() );
                            if (user_sucess > 0)
                            {
                                showView(false, 0);
                                FillGrid();
                                ShowError("Equipment Updated Successfully", false);
                            }
                        }
                        else { ShowError("Equipment Name Already Exists.", true); }

                    }
                    else
                    {
                        if (BLEquipment.CheckExist(CommonUtil.con, tbName.Text.Trim(), 0))
                        {
                            ShowError("Equipment Name Already Exists!!", true);
                        }
                        else
                        {
                            int user_sucess1 = BLEquipment.Edit(CommonUtil.con, Convert.ToInt32(hid.Value), tbName.Text.Trim(), tbValue.Text.Trim(), ddlEqType.SelectedValue.ToString());
                            if (user_sucess1 > 0)
                            {
                                showView(false, 0);
                                FillGrid();
                                ShowError(" Equipment Created Successfully ", false);
                            }
                        }
                    }
                }
                else { ShowError("Value Required", true); }
            }
            else { ShowError("Equipment Name Required", true); }
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
        protected void gvEquipments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DAL.Equipment s = e.Row.DataItem as DAL.Equipment;
                e.Row.Cells[3].Text = s.CreateDate.ToString("MMM dd yyyy");
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

        protected void gvEquipments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEquipments.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        protected void ddlEqType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}