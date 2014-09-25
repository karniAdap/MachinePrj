<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminLogo.ascx.cs" Inherits="Machine.Web.common.AdminLogo" %>

<h1><span class="logo">
    <img id="imgLogo" style="max-width: 200px; max-height: 60px;" runat="server" alt="" /></span>
    <a href="#">
        <asp:Literal ID="ltLogo" runat="server"></asp:Literal>
    </a></h1>
<script type="text/javascript">
    function setFocus(objName) {
        if ($("." + objName)) {
            $("." + objName).focus();
        }
    }
    $(document).ready(function () {
        if ($(".tbName")) {
            setFocus("tbName");
        }
    });
</script>
