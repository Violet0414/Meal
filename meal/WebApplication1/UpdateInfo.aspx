<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateInfo.aspx.cs" Inherits="WebApplication1.signUp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn{
            margin-left:56.5%
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h2 style="margin-left:2%;">Update information</h2>
        </div>
        <div class="jumbotron" style="padding-bottom:30px">

            <div class="input-group" style="margin-bottom:2%">
              <span class="input-group-addon">&nbsp&nbsp&nbsp Name &nbsp&nbsp&nbsp</span>
                <asp:TextBox ID="TextName" runat="server" style="width:60%;" class="form-control" placeholder="Please enter your new nickname" aria-describedby="sizing-addon1"></asp:TextBox>
            </div>
            <div class="input-group" style="margin-bottom:2%">
              <span class="input-group-addon">&nbsp&nbsp&nbsp&nbsp Sex &nbsp&nbsp&nbsp&nbsp&nbsp</span>
              <asp:DropDownList ID="ddlSex" runat="server" CssClass="form-control" style="width:60%;">
                  <asp:ListItem Value="0">male</asp:ListItem>
                  <asp:ListItem Value="1">famale</asp:ListItem>
              </asp:DropDownList>
            </div>

            <div class="input-group" style="margin-bottom:2%">
              <span class="input-group-addon">Telephone</span>
             <asp:TextBox ID="TextTel" runat="server" style="width:60%;" class="form-control" placeholder="Please enter your new tel" aria-describedby="sizing-addon1"></asp:TextBox>
            </div>
            <div class="input-group" style="margin-bottom:2%">
              <span class="input-group-addon">&nbsp&nbsp&nbsp Email &nbsp&nbsp&nbsp</span>
              <asp:TextBox ID="TextEmail" runat="server" style="width:60%;" class="form-control" placeholder="Please enter your new email" aria-describedby="sizing-addon1" ></asp:TextBox>
                <asp:Label ID="Error" runat="server" Text="" ForeColor="Red" CssClass="errStyle"></asp:Label>
            </div>
            
            <div class="input-group" style="margin-bottom:2%">
              <span class="input-group-addon">&nbsp;Password</span>
              <asp:TextBox ID="TextPwd" runat="server" style="width:60%;" class="form-control" placeholder="Please enter your new password" aria-describedby="sizing-addon1"></asp:TextBox>
            </div>
            
            <div class="input-group" style="margin-bottom:2%">
              <span class="input-group-addon">&nbsp&nbsp;Address&nbsp&nbsp</span>
             <asp:TextBox ID="TextAddress" runat="server" style="width:60%;" class="form-control" placeholder="Please enter your new address" aria-describedby="sizing-addon1"></asp:TextBox>
            </div>

            <asp:Button id="btnUp" CssClass="btn btn-primary btn" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />
        </div>
    </div>

</asp:Content>
