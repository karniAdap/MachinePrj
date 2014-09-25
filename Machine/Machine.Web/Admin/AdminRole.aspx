<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminRole.aspx.cs" Inherits="Machine.Web.Admin.AdminRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Manage AdminRoles : Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage AdminRoles : Admin</h1>
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
            <div class="clear_fix"></div>
        </div>
        <asp:MultiView ID="mvAdminRole" runat="server" ActiveViewIndex="0">
            <asp:View ID="vList" runat="server">
                <div class="sparter">&nbsp;</div>
                <div class="manage_user">
                    <asp:GridView ID="gvAdminRole" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record found"
                        DataKeyNames="AdminId">
                        <Columns>
                            <asp:BoundField DataField="AdminName" HeaderText="Admin Name" />
                            <asp:TemplateField HeaderText="IsAdmin">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" Checked='<%#Eval("IsAdmin") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="IsTrail">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkTrail" runat="server" Checked='<%#Eval("IsTrail") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>                            
                        </Columns>
                    </asp:GridView> 
                    <asp:Button ID="btnWeekenUpdate" runat="server" CssClass="search_button" Text="Update AdminRole" OnClick="btnWeekenUpdate_Click" />
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
