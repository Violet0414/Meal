<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="WebApplication1.Comment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/UpdateInfo.css" rel="stylesheet" type="text/css" /> 
    <div class="container">
        <div class="jumbotron">
            <h2 style="margin-left:2%;">Upload comments</h2>
        </div>
        <div class="jumbotron" style="padding-bottom:30px">

            <div class="input-group">
              <span class="input-group-addon">&nbsp&nbsp Grades &nbsp&nbsp</span>
                <asp:TextBox ID="TextGrades" runat="server" style="width:60%;" class="form-control" placeholder="Please enter your score for the dishes(1 ~ 5)" aria-describedby="sizing-addon1"></asp:TextBox>
            </div>
            <div class="input-group">
              <span class="input-group-addon">&nbsp Evaluate &nbsp</span>
            <asp:TextBox ID="TextContent" runat="server" style="width:80%; height:300px;" class="form-control" placeholder="Please enter your comments on the dishes" aria-describedby="sizing-addon1" TextMode="MultiLine"></asp:TextBox>
            </div>
            
            <asp:Button id="btnUp" CssClass="btn btn-primary" style="margin-left: 68.5%;" runat="server" Text="Upload comments" onClick="upLoad"/>
        </div>
    </div>
</asp:Content>
