<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8" />
    <title>Login</title>
    <link rel="Shortcut Icon" href="image/IT.png" type="image/x-icon" />
    <link href="css/Login.css" rel="stylesheet" type="text/css"/>
</head>

<body>
    <form id="main" runat="server">
        
        <div id="avatar">
        </div>

        <div id="account" runat="server">
            <div class="input-box" runat="server">
                <asp:TextBox ID="txtEmail" CssClass="input" runat="server" placeholder="Please enter your email address"></asp:TextBox>
            </div>
            <div class="input-box">
                <asp:TextBox ID="txtPassword" CssClass="input" runat="server" TextMode="Password" placeholder="Please enter your password"></asp:TextBox>
            </div>
        </div>
        <div id="admin-div">
           <label for="ADMIN">Administrator login &nbsp;<asp:CheckBox ID="ADMIN" runat="server" /></label>
       </div>
        <asp:Button ID="Button1" CssClass="login-btn" runat="server" Text="Login" OnClick="Button1_Click" />
        

        <div id="footer">
            <a href="Register.aspx">User registration</a>
        </div>
            



    </form>

</body>
</html>
