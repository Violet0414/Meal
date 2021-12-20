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
    public partial class mUsers : System.Web.UI.Page
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
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

	    // 查询数据库内的用户表，将查到的用户全部显示到页面上
            string sqlQuery = "SELECT * FROM users";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            this.usersList.DataSource = reader;
            this.usersList.DataBind();
            reader.Close();
            conn.Close(); ;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton dbtn = (LinkButton)sender;
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


	    // 将所选择的用户从用户表中删除
            string sqlQuery = "DELETE FROM users WHERE id=@userId";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);

	    // 此处是通过CommandArgument传值获取到点击的具体是哪一个用户
            comm.Parameters.AddWithValue("@userId", dbtn.CommandArgument);
            int result = comm.ExecuteNonQuery();
            conn.Close();

            Response.Write("<script language=javascript>alert('Delete succeeded!');</" + "script>");
            Response.Redirect(Request.Url.ToString());
        }
    }
}