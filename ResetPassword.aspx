<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Reset Password Form</title>
    <link rel="stylesheet" href="Style.css" />
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />
    <script src="Script.js"></script>
</head>
<body>
    <div class="wrapper">
        <form runat="server">
            <h1>Reset Password</h1>
            <br />
            <asp:Label ID="errorMSG" runat="server" Text=""></asp:Label>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <div class="input-box">
                    <asp:TextBox ID="pass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                    <i class='bx bxs-lock-alt'></i>
                </div>
                <div class="input-box">
                    <asp:TextBox ID="conf_pass" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                    <i class='bx bxs-lock-alt'></i>
                </div>
                <div class="remember-forgo">
                    <input type="checkbox" onclick="myFunction()" />
                    <p>Show Password</p>
                </div>
                <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Reset" OnClick="Button1_Click" />
                <div class="register-link">
                    <asp:Label ID="login" runat="server" Visible="false"><p><a href="Login.aspx">Login</a></p></asp:Label>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Link is expired!"></asp:Label>
            </asp:PlaceHolder>
        </form>
    </div>
</body>
</html>
