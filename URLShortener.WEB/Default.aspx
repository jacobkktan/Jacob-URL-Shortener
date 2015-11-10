<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="URLShortener.WEB.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
        <asp:Button ID="btnGenerate" runat="server" Text="Generate ShortUrl" OnClick="btnGenerate_Click" />
        <br />
        <asp:Label ID="lblShortUrl" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
