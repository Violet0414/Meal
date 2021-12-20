<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ProcessOrders.aspx.cs" Inherits="WebApplication1.ProcessOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h2 style="margin-left:2%;">Process orders</h2>
        </div>
        <div class="jumbotron">
            <asp:DataList ID="PaddingList" runat="server" CssClass="table table-striped">
                <HeaderTemplate>
                    <th scope="col">User name</th>
                    <th scope="col">Dishes name</th>
                    <th scope="col">Number</th>
                    <th scope="col">Price</th>
                    <th scope="col">Time</th>
                    <th scope="col">Operate</th>
                </HeaderTemplate>
                <ItemTemplate>
                    <td><%#Eval("uname")%></td>
                    <td><%#Eval("dname")%></td>
                    <td><%#Eval("number")%></td>
                    <td><%#Eval("price")%>RM</td>
                    <td><%#Eval("time")%></td>
                    <td>
                        <asp:Button ID="btnProcess" CssClass="btn btn-sm btn-danger" OnClick="BtnProcess_Click"
                            CommandArgument='<%#Eval("oid")%>' runat="server" Text="Process" />
                    </td>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
