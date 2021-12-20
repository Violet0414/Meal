using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserName"] = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

		// 在登录界面若是勾选了管理员登录，则ADMIN.Checked为true
                if (ADMIN.Checked == true)
                {

		    // 查询管理员表，当输入的id和password与数据库内的值相等时，登录成功
                    string sqlQuery = "SELECT * FROM admin WHERE id=@email AND pwd=@password ";
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    comm.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    SqlDataReader reader = comm.ExecuteReader();

		    //当查询到数据后，跳转页面到用户管理页面，并将admin账号存入Session里
                    if (reader.Read() == true)
                    {
                        Session["Admin"] = txtEmail.Text.Trim();
                        Response.Redirect("ManageUsers.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Credentials!!!')</script>");
                    }
                    reader.Close();
                    conn.Close();
                }
                else
                {

		    // 若不是管理员登录则查询用户表，，判断用户输入的账号密码是否正确
                    string sqlQuery = "SELECT * FROM users WHERE email=@email AND pwd=@password ";
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    comm.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    SqlDataReader reader = comm.ExecuteReader();
		    // 若用户输入的正确则能查询到则将用户表内该用户的信息存入Session,方便其他页面使用
                    if (reader.Read() == true)
                    {
                        Session["uId"] = reader["id"].ToString();
                        Session["uEmail"] = reader["email"].ToString();
                        Session["uPwd"] = reader["pwd"].ToString();
                        Session["uName"] = reader["name"].ToString();
                        Session["uSex"] = reader["sex"].ToString();
                        Session["uTel"] = reader["tel"].ToString();
                        Session["uAddress"] = reader["address"].ToString();

                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Credentials!!!')</script>");
                    }
                    reader.Close();
                    conn.Close();
                }                
            }
        }
    }
}