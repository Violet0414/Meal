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
    public partial class MeunItem : System.Web.UI.Page
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
                Bind();
            }

        }

        protected void Bind()
        {
            string speciesId = Request.QueryString["id"];     // 获取传过来的参数（类别id）
            // 连接数据库
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            // 根据类别查询菜品
            string sqlQuery = "SELECT * FROM dishes where sid=" + speciesId;
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            // 将查询出来的结果集绑定到dishesList控件
            this.dishesList.DataSource = reader;
            this.dishesList.DataBind();
            reader.Close();
            conn.Close();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // 拿到btn传进来的CommandArgument参数，这个参数存的是菜品的id
            Button btn = (Button)sender;
            string dishId = btn.CommandArgument.ToString();     // 菜品id 
            double dishPrice = 0;           // 菜品的价格

            // 连接数据库
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            // 先查看当前用户的购物车有没有此菜品
            // 有就进行number+1操作
            // 没有就把此菜品加入到购物车
            string sqlQuery = "SELECT * FROM orders WHERE uid=@uid AND did=@did  AND state=0";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            comm.Parameters.AddWithValue("@uid", Session["uId"]);
            comm.Parameters.AddWithValue("@did", dishId);
            SqlDataReader reader = comm.ExecuteReader();
            Boolean flag = reader.Read();	// 查询的结果真假值保存在flag
            conn.Close();

            conn.Open();
            sqlQuery = "SELECT price FROM dishes WHERE id="+dishId;
            comm = new SqlCommand(sqlQuery, conn);
            reader = comm.ExecuteReader();

            if (reader.Read())
            {
                dishPrice = double.Parse(reader["price"].ToString());
            }
            conn.Close();

            // 判断当前会员购物车有无此菜品
            if (flag)
            {
		// 已经有此菜品
		// 在已有的基础上，数量+1，价格也加上
                conn.Open();
                sqlQuery = "UPDATE orders SET number=number+1,price=price+@dishPrice WHERE uid=@uid AND did=@did AND state=0";
                comm = new SqlCommand(sqlQuery, conn);
                comm.Parameters.AddWithValue("@uid", Session["uId"]);
                comm.Parameters.AddWithValue("@did", dishId);
                comm.Parameters.AddWithValue("@dishPrice", dishPrice);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
		// 没有此菜品，就插入一条新的记录
                conn.Open();
                sqlQuery = "INSERT INTO orders(uid,did,number,price,state) values(@uid,@did,1,@dishPrice,0)";
                comm = new SqlCommand(sqlQuery, conn);
                comm.Parameters.AddWithValue("@uid", Session["uId"]);
                comm.Parameters.AddWithValue("@did", dishId);
                comm.Parameters.AddWithValue("@dishPrice", dishPrice);
                comm.ExecuteNonQuery();
                conn.Close();
            }

            ClientScriptManager scriptManager = ClientScript;
            scriptManager.RegisterStartupScript(typeof(string), "", "alert('Successfully added to cart!');", true);
            conn.Close();
        }
    }

}