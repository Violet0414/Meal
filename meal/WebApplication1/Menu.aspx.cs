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
    public partial class Menu : System.Web.UI.Page
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
        public void Bind()
        {
            // 连接数据库
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            // 查询所有类别
            string sqlQuery = "SELECT * FROM species";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            // 将查询出来的结果集绑定到menu控件
            this.menu.DataSource = reader;
            this.menu.DataBind();
            reader.Close();
            conn.Close();
            


            

        }
    }
}