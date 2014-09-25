<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="PlantHirMachine.aspx.cs" Inherits="Machine.Web.Admin.PlantHirMachine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Plant Hire Machine : Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Plant Hire Machine : Admin</h1>
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

    <asp:MultiView ID="mvMachine" runat="server" ActiveViewIndex="0">
        <asp:View ID="vList" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet box grey-cascade">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-globe"></i>Manage Machine in Plant Hire 
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
                                    <asp:GridView ID="gvMachines" runat="server" AutoGenerateColumns="False" DataKeyNames="MachineId"
                                        CssClass="table table-striped table-bordered table-hover dataTable no-footer"
                                        AllowPaging="true" PageSize="25" OnPageIndexChanging="gvMachines_PageIndexChanging"
                                        OnRowCommand="gvMachines_RowCommand" OnRowDataBound="gvMachines_RowDataBound" EmptyDataText="No Record found">
                                        <Columns>
                                            <asp:BoundField DataField="HireDate" HeaderText="HireDate" />
                                            <asp:BoundField DataField="DocketNo" HeaderText="DocketNo" />
                                            <asp:BoundField DataField="StartHour" HeaderText="StartHour" />
                                            <asp:BoundField DataField="FinishHour" HeaderText="FinishHour" />
                                            <asp:BoundField DataField="Hours" HeaderText="Hours" />
                                            <asp:BoundField DataField="Plant" HeaderText="Plant" />
                                            <asp:BoundField DataField="Wet" HeaderText="Wet" />
                                            <asp:BoundField DataField="Nett" HeaderText="Nett" />
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button1" runat="server" CausesValidation="false" Text="Edit" CommandArgument="<%# Container.DataItemIndex %>" CommandName="MachineEdit" ToolTip="Edit" CssClass="edit_button" />
                                                    <asp:Button ID="Button2" CommandName="MachineDelete" CssClass="delete_button" Text="Delete" CommandArgument="<%# Container.DataItemIndex %>" ToolTip="Delete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
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
                            <label class="col-md-3 control-label">MachineName</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="tbName" MaxLength="30" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" SetFocusOnError="true" runat="server" CssClass="erralign"
                                    ErrorMessage="*Machine Name Required" ControlToValidate="tbName" ForeColor="Red"></asp:RequiredFieldValidator>
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
