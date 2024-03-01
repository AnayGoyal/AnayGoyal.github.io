<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestCaptcha.aspx.cs" Inherits="TestCaptcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image runat="server" ID="captchaImage" Height="80px" Width="300px" ImageUrl="~/MyCaptcha.aspx"> </asp:Image>
            <asp:TextBox ID="captchaCode" runat="server" class="form-control p-4" ></asp:TextBox>
        </div>
    </form>
</body>
</html>
