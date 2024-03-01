<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="anay_goyal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registration Form</title>
    <link rel="stylesheet" href="Style.css" />
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />
    <script src="Script.js"></script>
</head>
<body>
    <form runat="server">
        <div class="wrapper">
            <h1>Registration</h1>
            <br />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <div class="input-box">
                <asp:TextBox ID="email" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                <i class='bx bxl-gmail'></i>
            </div>
            <div class="input-box">
                <asp:TextBox ID="name" runat="server" placeholder="Name" TextMode="SingleLine"></asp:TextBox>
                <i class='bx bx-rename'></i>
            </div>
            <anay_goyal:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="pass" StrengthIndicatorType="BarIndicator" BarBorderCssClass="barcss" PrefixText="Password Strength: " HelpStatusLabelID="label" PreferredPasswordLength="8" MinimumNumericCharacters="1" MinimumUpperCaseCharacters="1" MinimumLowerCaseCharacters="1" MinimumSymbolCharacters="1" TextStrengthDescriptionStyles="poor;strong;advanced" />
            <div class="input-box">
                <asp:TextBox ID="pass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <i class='bx bxs-lock-alt'></i>
            </div>
            <div class="remember-forgo">
                <input type="checkbox" onclick="myFunction()" />
                <p>Show Password</p>
            </div>
            <label id="label"></label>
            <%--<asp:RegularExpressionValidator ID="RegExForPassword5" runat="server" ControlToValidate="pass" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,20}" ErrorMessage="Password must contain: 8-20 charecters atleast 1 Upper and 1 Lower Alphabet, 1 Number and 1 Special Character" ForeColor="Red"></asp:RegularExpressionValidator>--%>
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="form-group">
                    <label class="control-label col-sm-3" for="address">Country :</label>
                    <div class="col-sm-9">
                        <asp:UpdatePanel ID="countrypanel" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlcountry" AutoPostBack="true" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlcountry" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="form-group">
                    <label class="control-label col-sm-3" for="address">State :</label>
                    <div class="col-sm-9">
                        <asp:UpdatePanel ID="statepanel" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlstate" AutoPostBack="true" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlstate" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="form-group">
                    <label class="control-label col-sm-3" for="address">City :</label>
                    <div class="col-sm-9">
                        <asp:UpdatePanel ID="citypanel" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlcity" AutoPostBack="true" AppendDataBoundItems="true" runat="server" class="form-control"></asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlcity" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="input-box">
                <asp:Image ImageAlign="Middle" runat="server" ID="captchaImage" Height="50px" Width="150" ImageUrl="~/MyCaptcha.aspx" CssClass="image"></asp:Image>
            </div>
            <div class="input-box">
                <asp:TextBox ID="captchaCode" runat="server" class="form-control p-4" placeholder="Captcha Code"></asp:TextBox>
                <i class='bx bx-code-alt'></i>
            </div>
            <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
            <div class="register-link">
                <p>Already have an Account?  <a href="Login.aspx">Login</a></p>
            </div>
        </div>
    </form>
</body>
</html>
