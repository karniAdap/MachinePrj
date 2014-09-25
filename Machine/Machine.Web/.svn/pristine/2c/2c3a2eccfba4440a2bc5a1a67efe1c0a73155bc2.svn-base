<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Machine.Web.Admin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Manage Users : Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Users : Admin</h1>
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

    <div class="col-md-6 col-sm-12">
        <div class="dataTables_length" id="Div2">
            <label>
                User Type
                <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged" class="form-control  input-inline">
                    <asp:ListItem Value="True" Text="Admin"></asp:ListItem>
                    <asp:ListItem Value="False" Text="Supervisor"></asp:ListItem>                    
                </asp:DropDownList>
            </label>
        </div>
    </div>
    <asp:MultiView ID="mvUser" runat="server" ActiveViewIndex="0">
        <asp:View ID="vList" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box grey-cascade">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-globe"></i>Manage User 
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="dataTables_wrapper no-footer">
                                <div class="row">
                                    <%-- <div class="col-md-6 col-sm-12">
                                            <div class="dataTables_length" id="Div2">
                                                <label>
                                                    <select name="sample_1_length" aria-controls="sample_1" class="form-control input-xsmall input-inline">
                                                        <option value="5">5</option>
                                                        <option value="15">15</option>
                                                        <option value="20">20</option>
                                                        <option value="-1">All</option>
                                                    </select>
                                                    records
                                                </label>
                                            </div>
                                        </div>--%>
                                    <div class="col-md-6 col-sm-12">
                                        <div id="Div3" class="dataTables_filter">
                                            Search:<asp:TextBox ID="tbSearch" CssClass="form-control input-small input-inline" runat="server"></asp:TextBox>
                                            <asp:Button ID="btnFilter" runat="server" CssClass="search_button" Text="Search" OnClick="btnFilter_Click" />
                                            <asp:Button ID="btnReset" runat="server" CssClass="search_button" Text="Reset" OnClick="btnReset_Click" />
                                        </div>
                                    </div>
                                    <div class="btn-group">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn green" Text="Add" OnClick="btnAdd_Click" />
                                        <asp:HiddenField ID="hid" runat="server" Value="0" />
                                    </div>
                                </div>
                                <div class="table-scrollable">
                                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="UserId"
                                        CssClass="table table-striped table-bordered table-hover dataTable no-footer"
                                        AllowPaging="true" PageSize="25" OnPageIndexChanging="gvUsers_PageIndexChanging"
                                        OnRowCommand="gvUsers_RowCommand" OnRowDataBound="gvUsers_RowDataBound" EmptyDataText="No Record found">
                                        <Columns>
                                            <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                            <asp:BoundField DataField="CreateDate" HeaderText="Created Date" />
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button1" runat="server" CausesValidation="false" Text="Edit" CommandArgument="<%# Container.DataItemIndex %>" CommandName="UserEdit" ToolTip="Edit" CssClass="edit_button" />
                                                    <asp:Button CommandName="UserDelete" CssClass="delete_button" Text="Delete" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                                    <asp:Button ID="btnAssignGroup" runat="server" Visible="false" CausesValidation="false" Text="Assign Group" CommandArgument="<%# Container.DataItemIndex %>" CommandName="AssignGroup" ToolTip="Assign Group" CssClass="manager_private" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="dataTables_paginate paging_bootstrap_full_number" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vEdit" runat="server">
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
                            <label class="col-md-3 control-label">UserName</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="tbName" MaxLength="30" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" SetFocusOnError="true" runat="server" CssClass="erralign"
                                    ErrorMessage="*User Name Required" ControlToValidate="tbName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">Email Address</label>
                            <div class="col-md-4">
                                <div class="input-icon">
                                    <asp:TextBox ID="tbEmail" MaxLength="80" runat="server" class="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server" Display="Dynamic" CssClass="erralign"
                                        ErrorMessage="*Email Required" ControlToValidate="tbEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="ReEmail" Display="Dynamic" SetFocusOnError="true"
                                        CssClass="erralign" runat="server" ControlToValidate="tbEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                                        ErrorMessage="*Invalid Email" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group" id="divPass" runat="server">
                            <label class="col-md-3 control-label">Password</label>
                            <div class="col-md-4">
                                <div class="input-icon">
                                    <asp:TextBox ID="tbPass" MaxLength="20" runat="server" TextMode="Password" value="" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPass" SetFocusOnError="true" runat="server" CssClass="erralign" ErrorMessage="*Password Required" ControlToValidate="tbPass" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">First Name</label>
                            <div class="col-md-4">
                                <div class="input-icon">
                                    <asp:TextBox ID="tbFirstName" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" runat="server" CssClass="erralign" ErrorMessage="*First Name Required" ControlToValidate="tbFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">Last Name</label>
                            <div class="col-md-4">
                                <div class="input-icon right">
                                    <asp:TextBox ID="tbLastName" runat="server" MaxLength="50" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-actions fluid">
                        <div class="col-md-offset-3 col-md-9">
                            <asp:Button ID="btn_save" runat="server" Text="Save" class="search_button btn blue" OnClick="btn_save_Click" />
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="search_button btn default" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>

       <%-- <asp:View ID="vAssignGroup" runat="server">
            <h2>Assign Group</h2>
            <div class="user_form">
                <div class="user_pad">
                    <label>
                        User Name : 
                    </label>
                    <asp:Label ID="lbUserName" runat="server"></asp:Label>
                </div>
                <br />
                <div class="manage_user">
                    <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="False" DataKeyNames="GroupId" EmptyDataText="No Record found">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Group Name" />
                            <asp:TemplateField HeaderText="Assign">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" Checked='<%# Convert.ToBoolean(Eval("IsGroup")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="paddingLgroup">
                    <asp:Button ID="btnAssignGroup" runat="server" Text="Save" class="search_button" OnClick="btnAssignGroup_Click" />
                    <asp:Button ID="Button3" runat="server" class="search_button" CausesValidation="false" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
            </div>
        </asp:View>--%>
    </asp:MultiView>
</asp:Content>
