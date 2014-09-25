using System;
using System.Linq;
using System.Web.UI.WebControls;
using Machine.BAL;
using Machine.DAL;

namespace Machine.Web.Admin
{
    public partial class Users : AdminBasePage
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
            mvUser.ActiveViewIndex = index;
            tbName.Text = tbFirstName.Text = tbLastName.Text = tbPass.Text = tbEmail.Text = "";            
            btnAdd.Visible = index == 0 ? true : false;
            headerText.Text = IsEdit == true ? "Create User" : "Edit User";
            hid.Value = "0";
            error_msg.Visible = false;
            success_msg.Visible = false;

            tbName.ReadOnly = false;
            divPass.Visible = true;
            rfvPass.Enabled = true;
            tbName.Focus();
        }

        private void FillGrid()
        {
            var lst = BLUser.GetUserList(CommonUtil.con, Convert.ToBoolean(ddlUserType.SelectedValue), tbSearch.Text.Trim()).ToList();
            gvUsers.DataSource = lst;
            gvUsers.DataBind();
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
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
            if (e.CommandName == "UserEdit")
            {
                int UserId = Convert.ToInt32(gvUsers.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                DAL.User User = BLUser.GetUserDetail(CommonUtil.con, UserId);
                if (User != null)
                {
                    showView(false, 1);
                    hid.Value = UserId.ToString();
                    tbName.Text = User.UserName;
                    tbFirstName.Text = User.FirstName;
                    tbLastName.Text = User.LastName;
                    tbEmail.Text = User.Email;
                    
                    tbName.ReadOnly = true;
                    divPass.Visible = false;
                    rfvPass.Enabled = false;
                }
            }
          
            else if (e.CommandName == "UserDelete")
            {
                int UserId = Convert.ToInt32(gvUsers.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                int sucess_delete = Convert.ToInt32(BLUser.DeleteUser(CommonUtil.con, UserId));
                if (sucess_delete > 0)
                {
                    FillGrid();
                    ShowError("User deleted successfully.", false);
                }
                else
                {
                    ShowError("To delete user, please deselect assigned group.", true);
                }
                BLUser.GetUserDetail(CommonUtil.con, UserId);
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
                if (tbEmail.Text.Trim() != "")
                {
                    if (Convert.ToInt32(hid.Value) > 0)
                    {
                        int uid = BLUser.CheckEMail(CommonUtil.con, tbEmail.Text.Trim(), Convert.ToInt32(hid.Value));
                        if (!(uid > 0))
                        {
                            int user_sucess = BLUser.UserAddEdit(CommonUtil.con, Convert.ToInt32(hid.Value), "", "", tbFirstName.Text.Trim(), tbLastName.Text.Trim(), tbEmail.Text.Trim(), Convert.ToBoolean(ddlUserType.SelectedValue));
                            if (user_sucess > 0)
                            {
                                showView(false, 0);
                                FillGrid();
                                ShowError("User Updated Successfully", false);
                            }
                        }
                        else { ShowError("Email Already Exists.", true); }
                    }
                    else
                    {
                        if (BLUser.CheckExist(CommonUtil.con, tbName.Text.Trim(), 0))
                        {
                            ShowError("User Name Already Exists!!", true);
                        }
                        else
                        {
                            int uid = BLUser.CheckEMail(CommonUtil.con, tbEmail.Text.Trim(), 0);
                            if (!(uid > 0))
                            {
                                int user_sucess1 = BLUser.UserAddEdit(CommonUtil.con, Convert.ToInt32(hid.Value), tbName.Text.Trim(), tbPass.Text.Trim(), tbFirstName.Text.Trim(), tbLastName.Text.Trim(), tbEmail.Text.Trim(), Convert.ToBoolean(ddlUserType.SelectedValue));
                                if (user_sucess1 > 0)
                                {
                                    showView(false, 0);
                                    FillGrid();
                                    ShowError(" New Account Created Successfully ", false);
                                }
                            }
                            else { ShowError("Email Already Exists.", true); }
                        }
                    }
                }
                else { ShowError("Email Required", true); }
            }
            else { ShowError("User Name Required", true); }

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

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DAL.User s = e.Row.DataItem as DAL.User;
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

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}