<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminChangePassword.aspx.cs" Inherits="Machine.Web.Admin.AdminChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Admin Password Change
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Admin Password Change</h1>
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

    <div class="portlet box green">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-gift"></i>
                <asp:Label ID="headerText" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="portlet-body form">
            <div class="form-body">
                <div class="form-group">
                    <label class="col-md-3 control-label">Admin Name</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="tbName" CssClass="widthinput" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="required1" CssClass="erralign" runat="server" ControlToValidate="tbName" ForeColor="Red" ErrorMessage="Admin Name Required"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <div class="form-group" id="divPass" runat="server">
                    <label class="col-md-3 control-label">Old Password</label>
                    <div class="col-md-4">
                        <div class="input-icon">
                            <asp:TextBox ID="tbOldPass" CssClass="widthinput" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="erralign" runat="server" ControlToValidate="tbOldPass" ForeColor="Red" ErrorMessage="Old Password Required"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">New Password</label>
                    <div class="col-md-4">
                        <div class="input-icon">
                            <asp:TextBox ID="tbNewPass" CssClass="widthinput" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="erralign" runat="server" ControlToValidate="tbNewPass" ForeColor="Red" ErrorMessage="New Password Required"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Confirm Password</label>
                    <div class="col-md-4">
                        <div class="input-icon right">
                            <asp:TextBox ID="tbNewCnfrmPass" CssClass="widthinput" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" CssClass="erralign" runat="server" ControlToValidate="tbNewCnfrmPass" ForeColor="Red" ErrorMessage="Confirm Password Required"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" CssClass="erralign" ErrorMessage="Password Not Matched" ControlToCompare="tbNewPass" ControlToValidate="tbNewCnfrmPass" ForeColor="Red"></asp:CompareValidator>

                        </div>
                    </div>
                </div>
            </div>
            <div class="form-actions fluid">
                <div class="col-md-offset-3 col-md-9">
                    <asp:Button ID="btn_save" runat="server" Text="Save" class="search_button" OnClick="btn_save_Click" />
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="search_button" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
