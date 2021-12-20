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
                <asp:TextBox ID="txtEmail" CssClass="input" runat="server" placeholder="请输入您的邮箱"></asp:TextBox>
            </div>
            <div class="input-box">
                <asp:TextBox ID="txtPassword" CssClass="input" runat="server" TextMode="Password" placeholder="请输入您的密码"></asp:TextBox>
            </div>
        </div>
        <div id="admin-div">
           <label for="ADMIN">管理员登录&nbsp;<asp:CheckBox ID="ADMIN" runat="server" /></label>
       </div>
        <asp:Button ID="Button1" CssClass="login-btn" runat="server" Text="登录" OnClick="Button1_Click" />
        

        <div id="footer">
            <a href="Register.aspx">注册用户</a>
        </div>
            



    </form>

</body>
</html>
