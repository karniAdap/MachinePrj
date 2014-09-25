<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Machine.Web.Admin.PasswordReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Password Reset Requests
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Password Reset Requests</h1>
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
    <div class="dashboard">
        <div class="search_box">
            <div class="search" id="divSearch" runat="server">
                <div>
                    <asp:TextBox ID="tbSearch" CssClass="widthinput" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFilter" runat="server" CssClass="search_button" Text="Search" OnClick="btnFilter_Click" />
                     <asp:Button ID="btnReset" runat="server"  CssClass="search_button" Text="Reset"  OnClick="btnReset_Click"  />
                    
                </div>
            <div class="f_right">
                <asp:HiddenField ID="hid" runat="server" Value="0" />
            </div>
                </div>
        </div>
        <div class="sparter">&nbsp;</div>
        <asp:MultiView ID="mvUser" runat="server" ActiveViewIndex="0">
            <asp:View ID="vList" runat="server">
                <div class="manage_user">
                    <asp:GridView ID="PasswordGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" EmptyDataText="No Record found" 
                        OnRowCommand="PasswordGrid_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="User Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />

                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandArgument="<%# Container.DataItemIndex %>" CommandName="ResetPassword" ToolTip="Edit" CssClass="edit_button" />
                                    
                                    <asp:Button ID="Button2" CommandName="UserDelete" CssClass="delete_button" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record!');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="vEdit" runat="server">
                <div class="user_form">
                    <div class="user_pad">
                        <label>User Name<span class="required">*</span></label>
                        <asp:TextBox ID="tbName" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="user_pad">
                        <label>Password<span class="required">*</span></label>
                        <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" CssClass="erralign" runat="server" ErrorMessage="*Password Required" ControlToValidate="tbPass" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                     <div class="user_pad">
                        <label>Message<span class="required">*</span></label>
                        <asp:TextBox ID="txtBoxMsg" runat="server" TextMode="MultiLine" class="reset_textarea" MaxLength="200" CssClass="reset_textarea" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="paddingL143" >
                        <asp:Button ID="btn_save" runat="server" Text="Save" class="search_button" OnClick="btn_save_Click"  />
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="search_button" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>

    </div>
</asp:Content>
