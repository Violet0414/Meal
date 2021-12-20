<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageDishes.aspx.cs" Inherits="WebApplication1.mDishes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="css/UpdateInfo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="container">
        <div class="jumbotron">
            <h2 style="margin-left:2%;">Upload new dishes</h2>
        </div>
        <div class="jumbotron" style="padding-bottom:30px">

            <div class="input-group" runat="server">
                <span class="input-group-addon">Select dish type</span>
                <asp:DropDownList ID="selectList" runat="server" CssClass="input" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataBase %>" SelectCommand="SELECT * FROM [species]"></asp:SqlDataSource>
            </div>

            <div class="input-group">
                <span class="input-group-addon">New Dishes</span>
                <asp:TextBox ID="dishName" runat="server" style="width:60%;" class="form-control" placeholder="Please enter your new dish" aria-describedby="sizing-addon1"></asp:TextBox>
            </div>

            <div class="input-group">
                <span class="input-group-addon">&nbsp&nbsp&nbsp&nbsp&nbsp Price &nbsp&nbsp&nbsp&nbsp</span>
                <asp:TextBox ID="dishPrice" runat="server" style="width:60%;" class="form-control" placeholder="Please enter the price of the dish" aria-describedby="sizing-addon1"></asp:TextBox>
            </div>

            <div class="input-group">
                <label for="File">Upload pictures of dishes</label>
                <asp:FileUpload ID="File" runat="server" />
            </div>
            


            <asp:Button id="btnUp" CssClass="btn btn-primary" style="margin-left: 68.5%;" runat="server" Text="Upload dishes" onClick="Upload_Click"/>
        </div>
        <div class="jumbotron">
            <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" EmptyDataText="没有可显示的数据记录。" CellPadding="4" ForeColor="#333333" GridLines="None">
                
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>

                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" DeleteText="Delete"  />
                    <asp:CommandField HeaderText="Edit" ShowEditButton="True" DeleteText="Delete" EditText="Edit" />
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="sid" HeaderText="sid" SortExpression="sid" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                    <asp:BoundField DataField="image" HeaderText="image" SortExpression="image" />

                    <asp:ButtonField Text="按钮" />

                </Columns>

                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

            </asp:GridView>




            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DataBase %>" DeleteCommand="DELETE FROM [dishes] WHERE [id] = @id" InsertCommand="INSERT INTO [dishes] ([sid], [name], [price], [image]) VALUES (@sid, @name, @price, @image)" ProviderName="<%$ ConnectionStrings:DataBase.ProviderName %>" SelectCommand="SELECT [id], [sid], [name], [price], [image] FROM [dishes]" UpdateCommand="UPDATE [dishes] SET [sid] = @sid, [name] = @name, [price] = @price, [image] = @image WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="sid" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="price" Type="Double" />
                    <asp:Parameter Name="image" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="sid" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="price" Type="Double" />
                    <asp:Parameter Name="image" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
