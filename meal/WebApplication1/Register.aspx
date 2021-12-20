<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8" />
    <title>Register</title>
    <script type="text/javascript" src="Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/Login.css" rel="stylesheet" type="text/css"/>
</head>

<body>
    <form id="main" runat="server">

        <div id="account" runat="server">
            <h4 style="text-align:center">&nbsp;</h4>
            <h2 style="text-align:center; color:white; margin-bottom:10%;">User registration</h2>
            
            <div class="input-box" runat="server" style="margin-bottom: 15%">
                <asp:TextBox ID="TextEmail" CssClass="input" runat="server" placeholder="Email"></asp:TextBox>
                <asp:Label ID="Error" runat="server" Text="" ForeColor="Red" CssClass="errStyle"></asp:Label>
            </div>
             <div class="input-box">
                <asp:TextBox ID="TextPwd" CssClass="input" runat="server" placeholder="Password"></asp:TextBox>
            </div>
            <div class="input-box" runat="server">
                <asp:TextBox ID="TextName" CssClass="input" runat="server" placeholder="Name"></asp:TextBox>
            </div>
            <div class="input-box" runat="server">
                <asp:TextBox ID="TextTel" CssClass="input" runat="server" placeholder="Tel"></asp:TextBox>
            </div>
            <div class="input-box" runat="server">
                <asp:DropDownList ID="TextSex" runat="server" CssClass="input">
                    <asp:ListItem Value="0">male</asp:ListItem>
                    <asp:ListItem Value="1">famale</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="input-box" runat="server">
                <asp:TextBox ID="TextAddress" CssClass="input" runat="server" placeholder="Address"></asp:TextBox>
            </div>
            <div style="height:10%; box-sizing: border-box; text-align:center; margin: 0 auto;">
                <asp:Label ID="nullError" runat="server" Text="" ForeColor="Red" CssClass="errStyle"></asp:Label> 
            </div>    
        </div>

        
        <asp:Button ID="signUp" CssClass="login-btn" runat="server" Text="Register" OnClick="Register_Click" />

        
          


    </form>
</body>
</html>
