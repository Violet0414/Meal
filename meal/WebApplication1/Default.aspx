<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/Default.css" rel="stylesheet" type="text/css" />

    <div class="jumbotron" style="height: 150px;">
        <h2 style="margin-top: -5px; margin-left:5%;">Hello,guest!</h2>
        <p style="margin-left:7%"> Welcome to my shop, which can satisfy your taste buds!</p>
    </div>
    
        <div class="row ">
            <div class="col-md-1"></div>
            <div class="col-md-4">

                <h3>Recommended dishes&nbsp<span class="label label-default">Dishes</span></h3>
                <p>Wellington steak</p>
                <p>Tiramisu</p>
                <p>lemon juice</p>

                <h3>Highest sales&nbsp<span class="label label-default">Hot</span></h3>
                <div style="margin-left: 15px">
                <asp:DataList ID="dishesList" runat="server">
                    <ItemTemplate>
                        <table class="d-outside">
                            <tr>
                                <td style="min-width:200px">
                                    <span class="d-name"><%#Eval("name") %></span>
                                </td>
                                <td>
                                    <span class="d-name">Sales volume:<%#Eval("sum") %></span> 
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                </div>
                

                <h3>Shop profile&nbsp<span class="label label-default">Profile</span></h3>
                <p>&nbsp&nbsp The goods sold in this shop include staple foods, desserts and snacks. The business hours are from 8 a.m. to 8 p.m. and the contact number is 1111111.</p>
            </div>



            <div class="col-md-1"></div>
        <div class="col-md-5" style="margin-top:10px;">
            <!-- 轮播图  -->
	        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
              <!-- Indicators -->
              <ol class="carousel-indicators">
                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
              </ol>

              <!-- Wrapper for slides -->
              <div class="carousel-inner" role="listbox">
                <div class="item active">
                  <img src="image/1.png" alt="..." >
                  <div class="carousel-caption">
                  </div>
                </div>
                <div class="item">
                  <img src="image/2.png" alt="...">
                  <div class="carousel-caption">
                  </div>
                </div>
                <div class="item">
                  <img src="image/3.png" alt="...">
                  <div class="carousel-caption">
                  </div>
                </div>
                
              </div>

              <!-- Controls -->
              <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left-1" aria-hidden="true" style="transform:rotate(180deg);">➤</span>
                <span class="sr-only">Previous</span>
              </a>
              <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right-1" aria-hidden="true">➤</span>
                <span class="sr-only">Next</span>
              </a>
            </div>
        </div>    
        <div class="col-md-1"></div>
    </div>



</asp:Content>



