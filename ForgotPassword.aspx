<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Forgot Password Form</title>
    <link rel="stylesheet" href="Style.css" />
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />
</head>
<body>
    <div class="wrapper">
        <form runat="server">
            <h1>Forgot Password</h1>
            <br />
            <asp:Label ID="errorMSG" runat="server" Text=""></asp:Label>
            <div class="input-box">
                <asp:TextBox ID="email" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                <i class='bx bxl-gmail'></i>
            </div>
            <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </form>
    </div>
</body>
</html>
