<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Change Password Form</title>
    <link rel="stylesheet" href="Style.css" />
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />
    <script src="Script.js"></script>
</head>
<body>
    <div class="wrapper">
        <form runat="server">
            <h1>Change Password</h1>
            <asp:Label ID="errorMSG" runat="server" Text=""></asp:Label>
            <div class="input-box">
                <asp:TextBox ID="pass" runat="server" placeholder="Old Password" TextMode="Password"></asp:TextBox>
                <i class='bx bxs-lock-alt'></i>
            </div>
            <div class="input-box">
                <asp:TextBox ID="pass2" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                <i class='bx bxs-lock-alt'></i>
            </div>
            <div class="input-box">
                <asp:TextBox ID="pass3" runat="server" placeholder="Confirm New Password" TextMode="Password"></asp:TextBox>
                <i class='bx bxs-lock-alt'></i>
            </div>
            <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Change" OnClick="Button1_Click" />
        </form>
    </div>
</body>
</html>
