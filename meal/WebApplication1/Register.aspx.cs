using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {

	    // 判断邮箱的输入是否符合规则
            Regex rx = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");
            if (!rx.IsMatch(this.TextEmail.Text)) //不匹配
            {
                this.Error.Text = "The email format is incorrect, please re-enter！";
            }
            else if (IsEmailExists(this.TextEmail.Text))
            {
                this.Error.Text = "The email has been sign up！";
            }
            else
            {
                if (TextName.Text.Trim() == "" || TextSex.SelectedValue.ToString()=="" || TextTel.Text.Trim() == "" || TextAddress.Text.Trim() == "" || TextEmail.Text.Trim() == "" || TextPwd.Text.Trim() == "")
                {
                    this.nullError.Text = "The input box cannot be empty!";
                }
                else
                {
                    string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();

		    // 将用户填入的信息插入到用户表中，完成注册
                    string sqlQuery =
                    "insert into users (email,pwd,name,sex,tel,address) values (@email,@password,@name,@sex,@tel,@address);";
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.Parameters.AddWithValue("@name", TextName.Text.Trim());
                    comm.Parameters.AddWithValue("@sex", TextSex.SelectedValue.ToString());
                    comm.Parameters.AddWithValue("@tel", TextTel.Text.Trim());
                    comm.Parameters.AddWithValue("@address", TextAddress.Text.Trim());
                    comm.Parameters.AddWithValue("@email", TextEmail.Text.Trim());
                    comm.Parameters.AddWithValue("@password", TextPwd.Text.Trim());
                    int result = comm.ExecuteNonQuery();
                    conn.Close();

                    Response.Write("<script language=javascript>alert('Registration success!');</" + "script>");
                    Response.Write("<script language='javascript'>window.open('Login.aspx');</script>");
                }  
            }
        }


        public Boolean IsEmailExists(string email)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

	    // 判断用户注册时输入的邮箱是否已经存在
            string sqlQuery = "SELECT * FROM users WHERE email=@email";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            comm.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read() == true)
            {
                return true;
            }
            reader.Close();
            conn.Close();
            return false;
        }
    }
}