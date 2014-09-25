<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Supervisor/Site.Master" CodeBehind="Default.aspx.cs" Inherits="Machine.Web.Supervisor.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    User : Dashboard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>User : Dashboard</h1>
    <div class="dashboard">
        <ul>
            <li>
                <div class="thumb">
                    <a class="lightbox" href="/Supervisor/MyProfile.aspx" title="My Profile">
                        <img src="/images/users.png" alt="My Profile" />
                    </a>
                </div>
                <h3><a href="/Supervisor/MyProfile.aspx" title="My Profile" class="dashboardAlign">My Profile</a></h3>
            </li> 
            <li>
                <div class="thumb">
                    <a class="lightbox" href="/Supervisor/ChangePassword.aspx" title="Change Password">
                        <img src="/images/AdminChangePassword.png" alt="Change Password" />
                    </a>
                </div>
                <h3><a href="/Supervisor/ChangePassword.aspx" title="Change Password" class="dashboardAlign">Change Password</a></h3>
            </li>

        </ul>
        <div style="clear: both"></div>
    </div>
</asp:Content>
