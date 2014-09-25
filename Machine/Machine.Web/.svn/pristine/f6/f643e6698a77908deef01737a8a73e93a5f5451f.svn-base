<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="Machine.Web.Supervisor.forgotPassword" %>
<%@ Register Src="~/common/logo.ascx" TagPrefix="uc1" TagName="logo" %>
<!DOCTYPE html>
<html>
<head>
    <title>Forgot Password</title>
    <link rel="stylesheet" href="../Content/style.css" type="text/css" media="screen" />
   
</head>
<body>
    <div id="header-wrap">
        <header>
            <hgroup>
                <uc1:logo runat="server" ID="logo" />
            </hgroup>
        </header>
    </div>
    <!-- content-wrap -->
    <div class="content-wrap">
        <section id="contact" class="clearfix">
            <h1>Forgot Password</h1>
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

            <div class="user_form">
                <form id="form1" runat="server">
                    <div class="user_pad">
                        <label>Email<span class="required">*</span></label>
                        <asp:TextBox name="name" ID="TxtEmail" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="erralign" Display="Dynamic" ErrorMessage="*Email Required" ControlToValidate="TxtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true" CssClass="erralign" Display="Dynamic" runat="server" ControlToValidate="TxtEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ErrorMessage="Invalid Email" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>

                    <div class="user_pad">
                        <label>Message<span class="required">*</span></label>
                        <asp:TextBox ID="txtBoxMsg" runat="server" TextMode="MultiLine" class="reset_textarea" MaxLength="200" CssClass="reset_textarea"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="true" runat="server" CssClass="erralign" ErrorMessage="*Message Required" ControlToValidate="txtBoxMsg" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paddingL143">
                        <asp:Button ID="btnSave" class="search_button" runat="server" Text="Submit" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="search_button" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </form>
            </div>

        </section>
    </div>
</body>
</html>
