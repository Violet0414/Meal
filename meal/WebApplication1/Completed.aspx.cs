using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Completed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                {
                    try
                    {
                        if (Session["uId"] == null)
                        {
                            Response.Redirect("Login.aspx");
                        }
                    }
                    catch { }


	      	    // 连接数据库
                    string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();



		    // 联合查询数据库获取数据库内订单表订单状态为已完成的订单
                    string sqlQuery = "select * from orders left join dishes on orders.did = dishes.id where uid =" + Session["uId"] + " and state = 3;";
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    SqlDataReader reader = comm.ExecuteReader();

		
		    // 将查询到的数据和页面显示的地方进行一个绑定
                    this.orderList.DataSource = reader;
                    this.orderList.DataBind();
                    reader.Close();
                    conn.Close();
                }
            }
        }
        protected void btnComment_Click(object sender, EventArgs e)
        {
            LinkButton cbtn = (LinkButton)sender;
            string cId = cbtn.CommandArgument;

	    // 将页面中获取到的oid存入Session中，方便页面跳转后使用订单id进行插入评论
            Session["oId"] = cId.ToString();

	    // 跳转到评论页面
            Response.Write("<script language='javascript'>window.open('Comment.aspx');</script>");
        }
    }
}