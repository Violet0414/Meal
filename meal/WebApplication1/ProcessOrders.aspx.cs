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
    public partial class ProcessOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Admin"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch { }

            Bind();
        }

        protected void Bind()
        {
            // 连接数据库
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sqlQuery = "SELECT orders.id AS oid,users.name AS uname,dishes.name AS dname,number,orders.price AS price,time FROM orders " +
                "LEFT JOIN dishes on did=dishes.id LEFT JOIN users on uid=users.id " +
                "WHERE state=1";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();


            this.PaddingList.DataSource = reader;
            this.PaddingList.DataBind();

            reader.Close();
            conn.Close();
        }

        protected void BtnProcess_Click(object sender, EventArgs e)
        {
            // 拿到btn传进来的CommandArgument参数，这个参数存的是orders表中的id
            Button btn = (Button)sender;
            string orderId = btn.CommandArgument.ToString();
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sqlQuery = "UPDATE orders SET state=state+1 WHERE id=@id";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            comm.Parameters.AddWithValue("@id", orderId);
            comm.ExecuteNonQuery();

            conn.Close();

            // 删除成功之后得重新绑定数据，更新一下显示的内容
            Bind();
        }
    }
}