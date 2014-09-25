<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Machine.Web.Supervisor.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    User :Change Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Change Password </h1>
    <div class="message_success" id="success_msg" runat="server" visible="false">
        <div class="f_left">
            <img src="../images/suseess.png">
        </div>
        <div class="f_left message_textSuccess" id="success_msg1" runat="server"></div>
        <div class="clear_fix"></div>
    </div>

    <div class="message_error" id="error_msg" runat="server" visible="false">
        <div class="f_left">
            <img src="../images/error.png">
        </div>
        <div class="f_left message_textError" id="error_msg1" runat="server"></div>
        <div class="clear_fix"></div>
    </div>
    <div class="dashboard ">
        <div class="user_form">
            <div class="user_pad" id="div3" runat="server">
                <label>User Name</label>
                <asp:TextBox ID="tbName" CssClass="widthinput" runat="server" Enabled="false" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="user_pad" id="div4" runat="server">
                <label>Password <span class="required">*</span></label>
                <asp:TextBox ID="tbOldPass" CssClass="widthinput" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="chPass" SetFocusOnError="true" CssClass="erralign" runat="server" ControlToValidate="tbOldPass" ForeColor="Red" ErrorMessage="Old Password Required"></asp:RequiredFieldValidator>
            </div>
            <div class="user_pad" id="div5" runat="server">
                <label>New Password <span class="required">*</span></label>
                <asp:TextBox ID="tbNewPass" CssClass="widthinput" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="chPass" CssClass="erralign" SetFocusOnError="true" runat="server" ControlToValidate="tbNewPass" ForeColor="Red" ErrorMessage="New Password Required"></asp:RequiredFieldValidator>
            </div>
            <div class="user_pad" id="div6" runat="server">
                <label>Confirm Password<span class="required">*</span></label>
                <asp:TextBox ID="tbNewCnfrmPass" CssClass="widthinput" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ValidationGroup="chPass" SetFocusOnError="true" CssClass="erralign" runat="server" ControlToValidate="tbNewCnfrmPass" ForeColor="Red" ErrorMessage="Confirm Password Required"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="chPass" Display="Dynamic" CssClass="erralign" ErrorMessage="Password Not Matched" ControlToCompare="tbNewPass" ControlToValidate="tbNewCnfrmPass" ForeColor="Red"></asp:CompareValidator>
            </div>

            <div class="paddingL143">
                <asp:Button ID="btn_save" runat="server" Text="Save" class="search_button" ValidationGroup="chPass" OnClick="btn_save_Click" />
                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="search_button" Text="Cancel" PostBackUrl="~/Supervisor/Default.aspx" />
            </div>
        </div>
    </div>
</asp:Content>
