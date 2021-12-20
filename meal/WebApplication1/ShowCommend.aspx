<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCommend.aspx.cs" Inherits="WebApplication1.ShowCommand" %>

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
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <asp:DataList ID="CommendList" runat="server" CssClass="table table-striped" >
                    <ItemTemplate>
                        <td style="font-size:16px">
                            <span>Commend time: <%#Eval("time") %>
                                <br />
                            <span>Evaluation grade(1-5): <%#Eval("grade") %></span>
                            <p> <%#Eval("comment") %></p>
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </form>
</body>
</html>
