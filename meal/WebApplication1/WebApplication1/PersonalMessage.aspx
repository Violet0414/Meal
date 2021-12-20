<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PersonalMessage.aspx.cs" Inherits="WebApplication1.PersonalMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/UpdateInfo.css" rel="stylesheet" type="text/css" /> 

    <div class="container">
        <div class="jumbotron" style="margin-left:3%; margin-right:3%;">
            <h2 style="margin-left:2%;">Personal Data</h2>
        </div>

        <div class="jumbotron" >
            <div class="input-group">
              <span class="input-group-addon">&nbsp&nbsp&nbsp;Name &nbsp&nbsp&nbsp</span>
                <asp:TextBox ID="TextName" runat="server"  class="form-control" placeholder="Please enter your new nickname" aria-describedby="sizing-addon1" disabled="disabled" style="background-color:white;"></asp:TextBox>
            </div>
            <div class="input-group" style="margin-bottom:2%">
              <span class="input-group-addon">&nbsp&nbsp&nbsp&nbsp Sex &nbsp&nbsp&nbsp&nbsp&nbsp</span>
              <asp:DropDownList ID="ddlSex" runat="server" CssClass="form-control" disabled="disabled">
                  <asp:ListItem Value="0">male</asp:ListItem>
                  <asp:ListItem Value="1">famale</asp:ListItem>
              </asp:DropDownList>
            </div>

            <div class="input-group">
              <span class="input-group-addon">Telephone</span>
             <asp:TextBox ID="TextTel" runat="server"  class="form-control" placeholder="Please enter your new nickname" aria-describedby="sizing-addon1" disabled="disabled" style="background-color:white;"></asp:TextBox>
            </div>
            <div class="input-group">
              <span class="input-group-addon">&nbsp&nbsp&nbsp Email &nbsp&nbsp&nbsp</span>
              <asp:TextBox ID="TextEmail" runat="server"  class="form-control" placeholder="Please enter your new nickname" aria-describedby="sizing-addon1" disabled="disabled" style="background-color:white;"></asp:TextBox>
            </div>

            <div class="input-group">
              <span class="input-group-addon">&nbsp;Password</span>
              <asp:TextBox ID="TextPwd" runat="server"  class="form-control" placeholder="Please enter your new nickname" aria-describedby="sizing-addon1" disabled="disabled" style="background-color:white;"></asp:TextBox>
            </div>
            <div class="input-group">
              <span class="input-group-addon">&nbsp&nbsp;Address&nbsp&nbsp</span>
              <asp:TextBox ID="TextAddress" runat="server"  class="form-control" placeholder="Please enter your new nickname" aria-describedby="sizing-addon1" disabled="disabled" style="background-color:white;"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
