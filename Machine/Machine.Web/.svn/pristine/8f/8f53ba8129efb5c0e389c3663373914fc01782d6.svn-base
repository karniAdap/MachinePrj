<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Equipment.aspx.cs" Inherits="Machine.Web.Admin.Equipment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Manage Equipments : Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Equipments : Admin</h1>
    <div class="message_success" id="success_msg" runat="server" visible="false" enableviewstate="false">
        <div class="f_left">
            <img src="../images/suseess.png">
        </div>
        <div class="f_left message_textSuccess" id="success_msg1" runat="server"></div>
        <div class="clear_fix"></div>
    </div>

    <div class="message_error" id="error_msg" runat="server" visible="false" enableviewstate="false">
        <div class="f_left">
            <img src="../images/error.png">
        </div>
        <div class="f_left message_textError" id="error_msg1" runat="server"></div>
        <div class="clear_fix"></div>
    </div>

    <div class="col-md-6 col-sm-12">
        <div class="dataTables_length" id="Div2">
            <label>
                Equipment Type
                <asp:DropDownList ID="ddlEqType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEqType_SelectedIndexChanged" class="form-control input-xsmall input-inline">
                    <asp:ListItem Value="Vehicle" Text="Vehicle"></asp:ListItem>
                    <asp:ListItem Value="CostCode" Text="Cost Code"></asp:ListItem>
                    <asp:ListItem Value="Operator" Text="Operator Name"></asp:ListItem>
                    <asp:ListItem Value="Plant" Text="Plant"></asp:ListItem>
                </asp:DropDownList>
            </label>
        </div>
    </div>

    <asp:MultiView ID="mvEquipment" runat="server" ActiveViewIndex="0">
        <asp:View ID="vList" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box grey-cascade">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-globe"></i>Manage Equipment 
                            </div>
                        </div>

                        <div class="portlet-body">
                            <div class="dataTables_wrapper no-footer">
                                <div class="row">
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
                                    <asp:GridView ID="gvEquipments" runat="server" AutoGenerateColumns="False" DataKeyNames="EquipmentId"
                                        CssClass="table table-striped table-bordered table-hover dataTable no-footer"
                                        AllowPaging="true" PageSize="25" OnPageIndexChanging="gvEquipments_PageIndexChanging"
                                        OnRowCommand="gvEquipments_RowCommand" OnRowDataBound="gvEquipments_RowDataBound" EmptyDataText="No Record found">
                                        <Columns>
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="Value" HeaderText="Value" />
                                            <asp:BoundField DataField="EqType" HeaderText="Type" />
                                            <asp:BoundField DataField="CreateDate" HeaderText="Created Date" />
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button1" runat="server" CausesValidation="false" Text="Edit" CommandArgument="<%# Container.DataItemIndex %>" CommandName="EquipmentEdit" ToolTip="Edit" CssClass="edit_button" />
                                                    <asp:Button CommandName="EquipmentDelete" CssClass="delete_button" Text="Delete" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
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
                            <label class="col-md-3 control-label">EquipmentName</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="tbName" MaxLength="30" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" SetFocusOnError="true" runat="server" CssClass="erralign"
                                    ErrorMessage="*Equipment Name Required" ControlToValidate="tbName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">Value</label>
                            <div class="col-md-4">
                                <div class="input-icon">
                                    <asp:TextBox ID="tbValue" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" runat="server" CssClass="erralign"
                                        ErrorMessage="*Value Required" ControlToValidate="tbValue" ForeColor="Red"></asp:RequiredFieldValidator>
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

    </asp:MultiView>

</asp:Content>
