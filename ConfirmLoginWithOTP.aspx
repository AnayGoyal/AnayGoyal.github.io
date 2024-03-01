<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmLoginWithOTP.aspx.cs" Inherits="ConfirmLoginWithOTP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Confirm Login OTP Form</title>
    <link rel="stylesheet" href="Style.css" />
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />
    <script src="Script.js"></script>
</head>
<body>
    <div class="wrapper">
        <form runat="server">
            <h1>Confirm Login OTP</h1>
            <asp:Label ID="errorMSG" runat="server" Text=""></asp:Label>
            <div class="input-box">
                <asp:TextBox ID="email" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                <i class='bx bxl-gmail'></i>
            </div>
            <div class="input-box">
                <asp:TextBox ID="pass" runat="server" placeholder="OTP" TextMode="Password"></asp:TextBox>
                <i class='bx bxs-lock-alt'></i>
            </div>
            <div class="remember-forgo">
                <input type="checkbox" onclick="myFunction()" />
                <p>Show Password</p>
            </div>
            <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        </form>
    </div>
</body>
</html>
