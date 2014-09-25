using System;
using System.Web.UI.WebControls;
using Machine.BAL;
using Machine.DAL;
namespace Machine.Web.Admin
{
    public partial class PasswordReset : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridFill();
            }
        }

        private void GridFill()
        {
            PasswordGrid.DataSource = BLUser.GetPasswordRequest(CommonUtil.con, tbSearch.Text.Trim());
            PasswordGrid.DataBind();
        }
        private void showView(bool IsEdit, int index)
        {
            mvUser.ActiveViewIndex = index;
            tbName.Text = tbPass.Text = "";
            divSearch.Visible = index == 0 ? true : false;
            hid.Value = "0";
            error_msg.Visible = false;
            success_msg.Visible = false;
            tbName.Focus();
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
        protected void PasswordGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ResetPassword")
            {
                int UserId = Convert.ToInt32(PasswordGrid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                DAL.User User = BLUser.GetUserPassDetail(UserId, CommonUtil.con);
                if (User != null)
                {
                    showView(true, 1);
                    hid.Value = UserId.ToString();
                    tbName.Text = User.UserName;
                    tbPass.Text = User.Pass;
                    txtBoxMsg.Text = User.Message;
                    tbName.ReadOnly = true;
                    txtBoxMsg.ReadOnly = true;
                }
            }
            else if (e.CommandName == "UserDelete")
            {
                int UserId = Convert.ToInt32(PasswordGrid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                int sucess_delete = Convert.ToInt32(BLUser.DeleteUser(CommonUtil.con, UserId));
                if (sucess_delete > 0)
                {
                    GridFill();
                    ShowError("User deleted successfully.", false);
                }
                else
                {
                    ShowError("User can't be deleted!!", true);
                }
                BLUser.GetUserDetail(CommonUtil.con, UserId);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (tbPass.Text.Trim() != "")
            {
                if (Convert.ToInt32(hid.Value) > 0)
                {
                    int user_sucess = BLUser.PasswordAdd(CommonUtil.con, Convert.ToInt32(hid.Value), tbPass.Text.Trim());
                    if (user_sucess > 0)
                    {
                        showView(false, 0);
                        GridFill();
                        ShowError("Password Updated Successfully", false);
                    }
                }
            }
            else { ShowError("Password Required", true); }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            showView(false, 0);
            GridFill();

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            GridFill();
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            showView(false, 0);
            GridFill();
        }
    }
}