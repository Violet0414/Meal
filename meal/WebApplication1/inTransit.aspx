<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="inTransit.aspx.cs" Inherits="WebApplication1.inTransit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container" style="background-color:#fff; font-size: 20px;" >
                <asp:DataList ID="orderList" runat="server" Width="100%" CssClass ="table table-striped">
                    <HeaderTemplate><th>DishName</th><th>Number</th><th>Price</th><th>Time</th><th>Operate</th></HeaderTemplate>
                    <ItemTemplate>
                        <td><%# Eval("name") %></td>
                        <td><%# Eval("number") %> </td>
                        <td><%# Eval("price")%>RM</td>
                        <td><%# Eval("time") %></td>
                        <td>
                            <asp:Button ID="btnConfirm" CssClass="btn btn-sm btn-success" OnClick="BtnConfirm_Click"
                            CommandArgument='<%#Eval("id")%>' runat="server" Text="Confirm receipt" />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
        </div>
</asp:Content>
