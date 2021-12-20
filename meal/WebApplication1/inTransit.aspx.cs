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
    public partial class inTransit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (Session["uId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch { }
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


	    // 查询订单表内所有状态为配送中的订单
            string sqlQuery = "select * from orders left join dishes on orders.did = dishes.id where uid =" + Session["uId"] + " and state = 2;";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();

            this.orderList.DataSource = reader;

	    // 绑定数据到前台页面加以显示
            this.orderList.DataBind();
            reader.Close();
            conn.Close();
            
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string orderId = btn.CommandArgument.ToString();
            // 连接数据库
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


	    // 更新订单状态，将点击的那条订单状态加一，将其变为已完成状态
            string sqlQuery = "UPDATE orders SET state=state+1,time=@time WHERE id=@id";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            comm.Parameters.AddWithValue("@id", orderId);
            comm.Parameters.AddWithValue("@time", DateTime.Now.ToString());
            comm.ExecuteNonQuery();
            conn.Close();
            Response.Redirect(Request.Url.ToString());
            Response.Write("<script>alert('Successful confirmation!')</script>");
        }
    }
}