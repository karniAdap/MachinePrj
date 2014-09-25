<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Machine.Web.Login" %>
<%@ Register Src="~/common/logo.ascx" TagPrefix="uc1" TagName="logo" %>
<!DOCTYPE html>
<html>
<head>
    <title>User Login</title>
    <link rel="stylesheet" href="../Content/style.css" type="text/css" media="screen" />
    <script src="/Scripts/jquery-1.7.1.js"></script>
   
</head>
<body>
    <div id="header-wrap">
        <div class="header">
            <hgroup>
                <uc1:logo runat="server" ID="logo" />
            </hgroup>
        </div>
    </div>
    <!-- content-wrap -->
    <div class="content-wrap">
        <div id="contact" class="clearfix section">
            <h1>Login</h1>
            <div class="primary">
                <form id="Form1" runat="server">
                    <div class="message_error" id="error_msg" runat="server" visible="false">
                        <div class="f_left">
                            <img src="../images/error.png">
                        </div>
                        <div class="f_left message_textError" id="error_msg1" runat="server"></div>
                        <div class="clear_fix"></div>
                    </div> 
                      <div>
                        <label>User Name<span class="required">*</span></label>
                        <asp:TextBox ID="tbName" CssClass="widthinput tbName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="required1"  runat="server" SetFocusOnError="true" ValidationGroup="loginval" ControlToValidate="tbName" CssClass="login_required" ForeColor="Red" ErrorMessage="User Name Required" ></asp:RequiredFieldValidator>
                    </div>

                    <div>
                        <label>Password<span class="required">*</span></label>
                        <asp:TextBox ID="tbPass" CssClass="widthinput" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" runat="server" ValidationGroup="loginval" CssClass="login_required" ControlToValidate="tbPass" ForeColor="Red" ErrorMessage="Password Required" ></asp:RequiredFieldValidator>
                    </div>

                    <div>
                        <asp:Button ID="btnLogin" Text="Login" CssClass="button" runat="server" OnClick="btnLogin_Click"  ValidationGroup="loginval"  />
                        <a class="forgotPassword" href="forgotPassword.aspx">Forgot Password</a>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
