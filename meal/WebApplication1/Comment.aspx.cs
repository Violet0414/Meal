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
    public partial class Comment : System.Web.UI.Page
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

        }

        protected void upLoad(object sender, EventArgs e)
        {
            // 连接数据库，将页面内输入的评论以及分数插入comment表
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlQuery =
            "insert into evaluate (oid,uid,comment,grade,time) values (@oid,@uid,@content,@grades,'" + DateTime.Now.ToString() + "');";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            
	    // 将存入Session中的订单id和用户id取出赋值给@xxx
	    comm.Parameters.AddWithValue("@oid", Session["oId"].ToString());
            comm.Parameters.AddWithValue("@uid", Session["uId"]);
            

	    // 将页面输入的评论和分数取出赋值给@xxx
            comm.Parameters.AddWithValue("@content", TextContent.Text.Trim());
            comm.Parameters.AddWithValue("@grades", TextGrades.Text.Trim());

            int result = comm.ExecuteNonQuery();
            conn.Close();

            Response.Write("<script>alert('Successful Comments!')</script>");
        }
    }
}