<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login Form</title>
    <link rel="stylesheet" href="Style.css" />
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />
    <script type="text/javascript" src="Script.js"></script>
</head>
<body>
    <div class="wrapper">
        <form runat="server">
            <h1>Login</h1>
            <asp:Label ID="errorMSG" runat="server" Text=""></asp:Label>
            <div class="input-box">
                <asp:TextBox ID="email" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                <i class='bx bxl-gmail'></i>
            </div>
            <div class="input-box">
                <asp:TextBox ID="pass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <i class='bx bxs-lock-alt'></i>
            </div>
            <div class="remember-forgo">
                <input type="checkbox" onclick="myFunction()" />
                <p>Show Password</p>
            </div>
            <div class="input-box">
                <asp:Image ImageAlign="Middle" runat="server" ID="captchaImage" Height="50px" Width="150" ImageUrl="~/MyCaptcha.aspx" CssClass="image"></asp:Image>
            </div>
            <div class="input-box">
                <asp:TextBox ID="captchaCode" runat="server" class="form-control p-4" placeholder="Captcha Code"></asp:TextBox>
                <i class='bx bx-code-alt'></i>
            </div>
            <div class="remember-forgot">
                <label>
                    <asp:CheckBox ID="Chkme" runat="server" Text="Remember Me" />
                </label>
                <a href="ForgotPassword.aspx">Forgot Password</a>
            </div>
            <div class="register-link">
                <p>Wan't to Login with OTP?  <a href="LoginWithOTP.aspx">Click Here</a></p>
            </div>
            <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
            <div class="register-link">
                <p>Don't have an Account?  <a href="Register.aspx">Register</a></p>
            </div>
        </form>
    </div>
</body>
</html>
