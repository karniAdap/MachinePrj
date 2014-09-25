<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageChart.aspx.cs" Inherits="Machine.Web.Admin.ManageChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Manage Chart: Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .tbpoint
        {
            width: 30px;
        }
    </style>
    <h1>Manage Chart: Admin</h1>
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
            <div class="f_right">
            </div>
        </div>
        <div class="sparter">&nbsp;</div>
        <div class="manage_user">
            <asp:GridView ID="gvChart" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" EmptyDataText="No Record found"
                OnRowCommand="gvChart_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:TemplateField HeaderText="Point1">
                        <ItemTemplate>
                            <asp:TextBox ID="tbP1" runat="server" Text='<%#Eval("P1") %>' CssClass="tbpoint"></asp:TextBox>
                         <%--   <asp:CompareValidator ID="cpP1" runat="server" ControlToValidate="tbP1" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' Type="Integer"></asp:CompareValidator>--%>
                            <asp:RequiredFieldValidator ID="rfvP1" runat="server" ControlToValidate="tbP1" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' ></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Point2">
                        <ItemTemplate>
                            <asp:TextBox ID="tbP2" runat="server" Text='<%#Eval("P2") %>' CssClass="tbpoint"></asp:TextBox>
                             <asp:CompareValidator ID="cpP2" runat="server" ControlToValidate="tbP2" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' Type="Double"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="rfvP2" runat="server" ControlToValidate="tbP2" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' ></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Point3">
                        <ItemTemplate>
                            <asp:TextBox ID="tbP3" runat="server" Text='<%#Eval("P3") %>' CssClass="tbpoint"></asp:TextBox>
                             <asp:CompareValidator ID="cpP3" runat="server" ControlToValidate="tbP3" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' Type="Double"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="rfvP3" runat="server" ControlToValidate="tbP3" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' ></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Point4">
                        <ItemTemplate>
                            <asp:TextBox ID="tbP4" runat="server" Text='<%#Eval("P4") %>' CssClass="tbpoint"></asp:TextBox>
                             <asp:CompareValidator ID="cpP4" runat="server" ControlToValidate="tbP4" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' Type="Double"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="rfvP4" runat="server" ControlToValidate="tbP4" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' ></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Point5">
                        <ItemTemplate>
                            <asp:TextBox ID="tbP5" runat="server" Text='<%#Eval("P5") %>' CssClass="tbpoint"></asp:TextBox>
                             <asp:CompareValidator ID="cpP5" runat="server" ControlToValidate="tbP5" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' Type="Double"></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="rfvP5" runat="server" ControlToValidate="tbP5" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true"
                                Display="Dynamic" ValidationGroup='<%#Eval("Id") %>' ></asp:RequiredFieldValidator>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btn" runat="server" CommandArgument="<%# Container.DataItemIndex %>" ValidationGroup='<%#Eval("Id") %>' CommandName="ChartUpdate" ToolTip="Update" CssClass="search_button" Text="Update" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <%-- <script type="text/javascript">
        $('.tbpoint').keyup(function () {
            //to allow decimals,use/[^0-9\.]/g 
            var regex = new RegExp(/[^0-9\.]/g);
            var containsNonNumeric = this.value.match(regex);
            if (containsNonNumeric)
                this.value = this.value.replace(regex, '');
        });
    </script>--%>
</asp:Content>
