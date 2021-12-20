<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WebApplication1.SoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="background-color:#fff; font-size: 20px;">
        <div class="row">
            <asp:DataList ID="CartList" runat="server" CssClass="table table-striped">
                <HeaderTemplate>
                    <th scope="col">Dish name</th>
                    <th scope="col">Quantity</th>
                    <th scope="col">Price</th>
                    <th scope="col">Operate</th>
                </HeaderTemplate>
                <ItemTemplate>
                    <td><%#Eval("name") %></td>
                    <td><%#Eval("number") %></td>
                    <td>
                        <%#Eval("price")%>RM
                    </td>
                    <td>
                        <asp:Button ID="btnDel" CssClass="btn btn-sm btn-danger" OnClick="BtnDel_Click"
                            CommandArgument='<%#Eval("oid")%>' runat="server" Text="Delete" />

                    </td>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <hr style="border-top:3px solid #ffd800"/>
        <div class="row">
            <div class="col-md-7"></div>
            <div class="col-md-3" style="font-size:24px">
                Total price:
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                &nbsp;RM
            </div>
            <div class="col-md-2">
                <asp:Button ID="BtnCheckOut" runat="server" Text="Check out" CssClass="btn btn-success" OnClick="BtnCheckOut_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
