<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UplandPSAClientIntiator.aspx.cs" Inherits="Tenrox.Web.Asp.Entry.Common.UplandPSAClientIntiator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" runat="server" id="orgname" name="orgname" />
        <input type="hidden" runat="server" id="token" name="token" />
    </form>
    <script type="text/javascript">
        window.location.href =
            "https://localhost:44382/upland-psa?orgname="
            + encodeURIComponent(document.getElementById("orgname").value)
            + "&token="
            + encodeURIComponent(document.getElementById("token").value);
    </script>
</body>
</html>
