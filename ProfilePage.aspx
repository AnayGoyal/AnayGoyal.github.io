<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <p align="right">
            <asp:PlaceHolder ID="loginPlaceHolder" runat="server">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Login.aspx">Login</asp:HyperLink>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="logoutPlaceHolder2" runat="server" Visible="false">Welcome <%=HttpContext.Current.Session["name"]%>,
                <asp:HyperLink ID="Hyperlink5" runat="server" NavigateUrl="~/Logout.aspx">Logout</asp:HyperLink>
            </asp:PlaceHolder>
        </p>
        <p align="left">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ProfilePage.aspx">Profile</asp:HyperLink>
        </p>
        <div>
            <b>Welcome</b><br />
            <asp:PlaceHolder ID="logoutPlaceHolder" runat="server" Visible="false">
                <b>Your name is: </b><%=HttpContext.Current.Session["name"] %><br />
                <b>Your email address is: </b><%=HttpContext.Current.Session["email"] %><br />
                <b>Want to Change Your Password?<a href="ChangePassword.aspx">Click Here</a></b>
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
