<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="WebApplication1.Menu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="css/menu.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <div class="container" runat="server">
        <div class="row">
            <div class="col-xs-2 col-sm-2 col-md-2 custom-menu">
                <div class="custom-menu-title" style="font-size:20px;margin-bottom:10px">Meum</div>
                <div class="custom-menu-content" style="font-size:20px;">
                    <asp:DataList ID="menu" runat="server" class="nav">
                        <ItemTemplate>

                                <%-- target：绑定到iframe框架，链接的内容显示到iframe框架中 --%>
                                <asp:HyperLink ID="item" CssClass="link" runat="server" 
                                    target="mainFrame" NavigateUrl='<%# "~/MenuItem.aspx?id="+Eval("id") %>'
                                    style="text-decoration: none" Height="40px" Width="180px">
                                    <%-- 查询出来的类别名 --%>
                                    &nbsp&nbsp;<%#Eval("name")%>
                                </asp:HyperLink>

                        </ItemTemplate>
                    </asp:DataList>
               
                </div>
            </div>
            <div class="col-xs-10 col-sm-10 col-md-10" style="z-index:1">
                    <!-- 添加iframe框架  HyperLink跳转的页面显示在这个框架里  不新建页面 -->
                <iframe id="iframe1" name="mainFrame" style="width: 100%; height: 600px;background-color:#fff" ></iframe>
                    
            </div>
        </div>
    </div>
    <script>
        // 进入页面时默认点击类别中的第一项
        // MainContent_menu_item_0这个id是DataList控件自动生成的
        var a = document.getElementById("MainContent_menu_item_0");
        // console.log(a);
        // 点击第一个类别
        a.click()
        // nowid是用来记录当前点击的类别
        var nowid = "MainContent_menu_item_0";
        // 修改将当前的类别的颜色
        document.getElementById(nowid).style.borderColor = "#563d7c";


        // 设置a标签的点击事件  HyperLink其实就是a标签
        $("a").click(function (event) {
            // 拿到点击的类别的id  也就是event.target.id
            var etid = event.target.id;
            // 判断一下长度 看看是不是类别的id
            if (etid.length == "MainContent_menu_item_0".length) {
                // 将原先选中的类别边框颜色改为白色 就看不见了
                document.getElementById(nowid).style.borderColor = "#fff";
                // 更新一下nowid
                nowid = etid;
                // 将新点击的类别的边框颜色改成#563d7c
                document.getElementById(etid).style.borderColor = "#563d7c";
            }
        });
    </script>
</asp:Content>
