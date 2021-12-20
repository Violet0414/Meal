<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pending.aspx.cs" Inherits="WebApplication1.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container" style="background-color:#fff; font-size: 20px;" >
                    <asp:DataList ID="orderList" runat="server" Width="100%" CssClass ="table table-striped">
                        <HeaderTemplate><th>DishName</th><th>Number</th><th>Price</th><th>Time</th></HeaderTemplate>
                        <ItemTemplate>
                                    <td><%# Eval("name") %></td>
                                    <td><%# Eval("number") %> </td>
                                    <td><%# Eval("price")%>RM</td>
                                    <td><%# Eval("time") %></td>
                        </ItemTemplate>
                    </asp:DataList>
        </div>
</asp:Content>
