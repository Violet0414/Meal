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
                if (ADMIN.Checked == true)
                {
                    string sqlQuery = "SELECT * FROM admin WHERE id=@email AND pwd=@password ";
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    comm.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    SqlDataReader reader = comm.ExecuteReader();
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
                    string sqlQuery = "SELECT * FROM users WHERE email=@email AND pwd=@password ";
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    comm.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    SqlDataReader reader = comm.ExecuteReader();
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