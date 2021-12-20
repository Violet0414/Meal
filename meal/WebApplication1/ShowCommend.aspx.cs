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
    public partial class ShowCommand : System.Web.UI.Page
    {
        private string speciesId;

        protected void Page_Load(object sender, EventArgs e)
        {
		// 获取传过来的参数，这个参数是菜品的id
            string dishId = Request.QueryString["did"];

            // 连接数据库
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
	    // 根据菜品id查询这个菜品的评论
            string sqlQuery = "SELECT e.time time,grade,comment FROM evaluate AS e LEFT JOIN orders on oid=orders.id WHERE did=" + dishId ;
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();

            this.CommendList.DataSource = reader;
            this.CommendList.DataBind();
            reader.Close();
            conn.Close();
        }
    }
}