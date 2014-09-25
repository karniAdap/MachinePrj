<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Machine.Web.Admin.AdminLogin" %>

<%@ Register Src="~/common/logo.ascx" TagPrefix="uc1" TagName="logo" %>

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
    <!-- BEGIN LOGO -->
    <style>
        .logonlogin{text-align: center!important;margin: 20px auto 0;}
        .logonlogin img{width: 358px !important;}
    </style>
    <div class="logo logonlogin">
        <a href="http://stagingserver10.com/time_machine/">
            <img alt="" src="http://stagingserver10.com/time_machine//admin/templates/whws/images/logomscs.png">
        </a>
    </div>
    <div class="menu-toggler sidebar-toggler"></div>
    <div class="content">
        <div id="userimageholder" class="profile-img">
            <img id="default_img" src="http://stagingserver10.com/time_machine//assets/users/default.png">
        </div>

        <form runat="server" class="login-form">
            <h3 class="form-title">Login to your account</h3> 
                <span id="error_msg" style="color:red;" runat="server" visible="false">Please enter username and password. </span> 
            <div class="form-group">
                <label class="control-label visible-ie8 visible-ie9">Email</label>
                <div class="input-icon">
                    <i class="fa fa-user"></i>
                    <asp:TextBox ID="tbName" CssClass="widthinput tbName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="required1" SetFocusOnError="true" CssClass="login_required" runat="server" ValidationGroup="loginval" ControlToValidate="tbName" ForeColor="Red" ErrorMessage="User Name Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label visible-ie8 visible-ie9">Password</label>
                <div class="input-icon">
                    <i class="fa fa-lock"></i>
                    <asp:TextBox ID="tbPass" CssClass="widthinput" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" CssClass="login_required" runat="server" ValidationGroup="loginval" ControlToValidate="tbPass" ForeColor="Red" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-actions">
                <label class="checkbox">
                    <asp:Button ID="btnLogin" Text="Login" CssClass="btn blue pull-right" runat="server" OnClick="btnLogin_Click" ValidationGroup="loginval" />                    
            </div>
            <div class="forget-password">
                <h4>Forgot your password ?</h4>
                <p>no worries, click <a href="ForgotPassword.aspx" id="forget-password">here</a> to reset your password. </p>
            </div>
            <input type="hidden" name="option" id="option" value="login" />
        </form>

        <%--<form class="forget-form" action="#" method="post">
            <h3>Forgot Password ?</h3>
            <p>Enter your e-mail address below to reset your password. </p>
            <div class="form-group">
                <div class="input-icon">
                    <i class="fa fa-envelope"></i>
                    <input class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="Email" name="email" />
                </div>
            </div>
            <div class="form-actions">
                <button type="button" id="back-btn" class="btn"><i class="m-icon-swapleft"></i>Back </button>
                <button type="submit" class="btn blue pull-right">Submit <i class="m-icon-swapright m-icon-white"></i></button>
            </div>
            <input type="hidden" name="option" id="Hidden1" value="forgotpassword" />
        </form>--%>
    </div>
    <div class="copyright">2014 &copy; Time Machine </div>

    <script type="text/javascript">
        $(document).ready(function () {
            if ($(".tbName")) {
                setFocus("tbName");
            }
        });
        function setFocus(objName) {
            $("." + objName).focus();
        }
    </script>
</body>
</html>
