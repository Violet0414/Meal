<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WebApplication1.mUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <div class="container" style="background-color:#fff; font-size: 20px;" >
            <asp:DataList ID="usersList" runat="server" Width="100%" CssClass ="table table-hover">
                <HeaderTemplate><th>Name</th><th>Email</th><th>Password</th></HeaderTemplate>
                <ItemTemplate>
                            <td><%# Eval("name") %></td>
                            <td><%# Eval("email") %> </td>
                            <td><%# Eval("pwd") %></td>
                            <td>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument = '<%# Eval("id") %>' OnClick="btnDelete_Click">Delete</asp:LinkButton>
                            </td>
                </ItemTemplate>
            </asp:DataList>
        </div>
</asp:Content>
