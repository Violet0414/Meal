using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SoppingCart : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                CartInfoBind();
                TotalPriceBind();
            }
        }
        protected void CartInfoBind()
        {
            // 连接数据库
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            // 两表联合查询
            // 查出此会员购物车中的商品
            string sqlQuery = "SELECT orders.id AS oid,name,number,orders.price AS price FROM orders LEFT JOIN dishes on did=dishes.id WHERE uid=@uid AND state=0";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            comm.Parameters.AddWithValue("@uid", Session["uId"]);
            SqlDataReader reader = comm.ExecuteReader();

            // 将查询出来的结果集绑定到CartList控件
            this.CartList.DataSource = reader;
            this.CartList.DataBind();

            reader.Close();
            conn.Close();
        }

 
        /// <summary>
        /// 求购物车中总价格
        /// </summary>
        protected void TotalPriceBind()
        {
            // 连接数据库
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sqlQuery = "SELECT SUM(price) AS sum FROM orders WHERE uid=@uid AND state=0";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            comm.Parameters.AddWithValue("@uid", Session["uId"]);
            SqlDataReader reader = comm.ExecuteReader();

            // 将查询出来的结果集绑定到CartList控件
            if (reader.Read())
            {
                this.Label1.Text = reader[0].ToString();

            }
            else
            {
		// 如果没查出结果，就表示购物车为空，价格就置为0
                this.Label1.Text = "0";
            }

            reader.Close();
            conn.Close();
        }


        /// <summary>
        /// 删除在购物车中所选的菜品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            // 拿到btn传进来的CommandArgument参数，这个参数存的是orders表中的id
            Button btn = (Button)sender;
            string orderId = btn.CommandArgument.ToString();

            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sqlQuery = "DELETE FROM orders WHERE id=@id";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            comm.Parameters.AddWithValue("@id", orderId);
            comm.ExecuteNonQuery();

            conn.Close();

            // 删除成功之后得重新绑定数据，更新一下显示的内容
            CartInfoBind();
            TotalPriceBind();
        }


        /// <summary>
        /// 结账  将state的值由0改为1
        /// 0表示在购物车  1表示已支付，待处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {

            // 连接数据库
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
        
            string sqlQuery = "UPDATE orders SET state=state+1,time=@time WHERE uid=@uid AND state=0";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            comm.Parameters.AddWithValue("@uid", Session["uId"]);
            comm.Parameters.AddWithValue("@time", DateTime.Now.ToString());
            comm.ExecuteNonQuery();
            conn.Close();

            Response.Write("<script>alert('Successful checkout!')</script>");

            // 支付成功之后得重新绑定数据，更新一下显示的内容
            CartInfoBind();
            TotalPriceBind();
        }
    }
}