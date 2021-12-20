<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageSpecies.aspx.cs" Inherits="WebApplication1.mSpecies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
            <div class="jumbotron">
                <h2 style="margin-left:2%;">Upload new dishes</h2>
            </div>
                <div class="jumbotron" style="padding-bottom:30px">

                    <div class="input-group">
                        <span class="input-group-addon">New Dishes</span>
                        <asp:TextBox ID="sName" runat="server" style="width:60%;" class="form-control" placeholder="Please enter your new dish" aria-describedby="sizing-addon1"></asp:TextBox>
                    </div>

                     <asp:Button id="btnUp" CssClass="btn btn-primary" style="margin-left: 68.5%;" runat="server" Text="Upload species" onClick="Upload_Click"/>
                </div>
            <div class="jumbotron">
                <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" EmptyDataText="没有可显示的数据记录。" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" DeleteText="Delete"/>
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" EditText="Edit" />
                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataBase %>" DeleteCommand="DELETE FROM [species] WHERE [id] = @id" InsertCommand="INSERT INTO [species] ([name]) VALUES (@name)" ProviderName="<%$ ConnectionStrings:DataBase.ProviderName %>" SelectCommand="SELECT [id], [name] FROM [species]" UpdateCommand="UPDATE [species] SET [name] = @name WHERE [id] = @id">
                        <DeleteParameters>
                            <asp:Parameter Name="id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="name" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="name" Type="String" />
                            <asp:Parameter Name="id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
            </div>
            
            </div>
</asp:Content>
