<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuItem.aspx.cs" EnableEventValidation="false" Inherits="WebApplication1.MeunItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server" style="padding:20px;">
        <asp:DataList ID="dishesList" runat="server" RepeatColumns="2">
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" class="auto-style1 img-thumbnail" style="margin-right:35px;margin-bottom:5px;width:400px">
                    <tr>
                        <td class="auto-style5" rowspan="4">                            
                            <asp:Image ID="Image1" ImageUrl='<%# "~/image/dishes/"+Eval("image") %>' CssClass="img-thumbnail" Height="150" Width="150" runat="server" />
                        </td>
                        <td >&nbsp;&nbsp;&nbsp;&nbsp;
                            <span class="lead"><%#Eval("name")%></span>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;
                            RM:&nbsp;<%#Eval("price")%>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ShowCommend.aspx?did="+Eval("id") %>'>
                                Click here to view comments</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAdd" CssClass="btn btn-success" OnClick="btnAdd_Click"
                               CommandArgument='<%#Eval("id")%>' runat="server" Text="Add to Cart" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>

    </form>
</body>
</html>
