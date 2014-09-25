<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Machine.Web.Admin.ForgotPassword" %>

<!DOCTYPE html>
<html>
<head>
    <title>Admin Login</title>
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE">
    <meta http-equiv="EXPIRES" content="0">

    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="/Content/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="/Content/css/simple-line-icons.css" rel="stylesheet" type="text/css" />
    <link href="/Content/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="/Content/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="/Content/css/bootstrap-switch.css" rel="stylesheet" type="text/css" />

    <link href="/Content/css/login-soft.css" rel="stylesheet" type="text/css" />

    <link href="/Content/css/components.css" rel="stylesheet" type="text/css" />
    <link href="/Content/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="/Content/css/layout.css" rel="stylesheet" type="text/css" />
    <link id="style_color" href="/Content/css/default.css" rel="stylesheet" type="text/css" />

    <script src="/Scripts/jquery-1.7.1.js"></script>
</head>
<%--<uc1:logo runat="server" ID="logo" />--%>
<body class="login">
    <div class="menu-toggler sidebar-toggler"></div>
    <div class="content">
        <div id="userimageholder" class="profile-img">
            <img id="default_img" src="http://stagingserver10.com/time_machine//assets/users/default.png">
        </div>
        <form id="Form1" runat="server" class="login-form">
            <h3>Forgot Password ?</h3>
            <p>Enter your e-mail address below to reset your password. </p>
            <div class="form-group">
                <div class="input-icon">
                    <i class="fa fa-envelope"></i>
                    <asp:TextBox name="name" ID="TxtEmail"  runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-actions">  
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" PostBackUrl="~/Admin/AdminLogin.aspx" />
                <asp:Button ID="btnSubmit" CssClass="btn blue pull-right" runat="server" Text="Submit" OnClick="btnSubmit_Click" />                
            </div> 
        </form>
    </div>
    <div class="copyright">2014 &copy; Time Machine </div>  
</body>
</html>
