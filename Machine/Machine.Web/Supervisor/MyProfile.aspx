<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="Machine.Web.Supervisor.MyProfile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    My Profile
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>My Profile</h1>
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
            <div class="user_pad" id="divName" runat="server">
                <label>User Name </label>
                <asp:TextBox ID="tbName" MaxLength="30" ReadOnly="true" Enabled="false" runat="server"></asp:TextBox>                
            </div>
            
            <div class="user_pad">
                <label>Email <span class="required">*</span></label>
                <asp:TextBox ID="tbEmail" MaxLength="80" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" CssClass="erralign" ErrorMessage="*Email Required" ControlToValidate="tbEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true" Display="Dynamic" CssClass="erralign" runat="server" ControlToValidate="tbEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ErrorMessage="Invalid Email" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div class="user_pad">
                <label>First Name <span class="required">*</span></label>
                <asp:TextBox ID="tbFirstName" MaxLength="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" runat="server" CssClass="erralign" ErrorMessage="*First Name Required" ControlToValidate="tbFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="user_pad">
                <label>Last Name</label>
                <asp:TextBox ID="tbLastName" runat="server" MaxLength="50"></asp:TextBox>
            </div>
            <div class="paddingL143">
                <asp:Button ID="btn_save" runat="server" Text="Save" class="search_button" OnClick="btn_save_Click" />
                 <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="search_button" Text="Cancel"  PostBackUrl="/Supervisor/Default.aspx" />
                 
            </div>
        </div>
    </div> 
</asp:Content>
