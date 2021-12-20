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
    public partial class Orders : System.Web.UI.Page
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

	    
	    // 查询当前用户所有订单中状态为待处理的所有订单
            string sqlQuery = "select * from orders left join dishes on orders.did = dishes.id where uid =" + Session["uId"] + " and state = 1;";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();

            this.orderList.DataSource = reader;
            this.orderList.DataBind();
            reader.Close();
            conn.Close();
        }
    }
}