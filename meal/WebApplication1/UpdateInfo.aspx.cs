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
    public partial class signUp : System.Web.UI.Page
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
                this.TextName.Text = Session["uName"].ToString();
		// 判断是0是1  下拉列表显示对应的男或女
                for (int i = 0; i < this.ddlSex.Items.Count; i++)
                {
                    ddlSex.Items[i].Selected = false;
                    if (ddlSex.Items[i].Value.Trim() == Session["uSex"].ToString())
                    {
                        ddlSex.Items[i].Selected = true;
                    }
                }
                this.TextPwd.Text = Session["uPwd"].ToString();
                this.TextAddress.Text = Session["uAddress"].ToString();
                this.TextTel.Text = Session["uTel"].ToString();
                this.TextEmail.Text = Session["uEmail"].ToString();
            }
        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            // 判断用户输入的邮箱是否符合规则
            Regex rx = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");
            if (!rx.IsMatch(this.TextEmail.Text)) //不匹配
            {
                this.Error.Text = "The email format is incorrect, please re-enter！";
            }
	    // 判断用户输入的邮箱是否已经被注册过
            else if (IsEmailExists(this.TextEmail.Text))
            {
                this.Error.Text = "The email has been sign up！";
            }
            else
            {
                string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

		// 根据用户在前台页面输入的信息字段，对应修改数据库内的用户信息
                string sqlQuery =
                "update users set sex=@sex,name=@name,tel=@tel,address=@address,email=@email,pwd=@password where id=" + Session["uId"].ToString() + ";";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.Parameters.AddWithValue("@name", TextName.Text.Trim());
                comm.Parameters.AddWithValue("@sex", ddlSex.SelectedValue.ToString());
                comm.Parameters.AddWithValue("@tel", TextTel.Text.Trim());
                comm.Parameters.AddWithValue("@address", TextAddress.Text.Trim());
                comm.Parameters.AddWithValue("@email", TextEmail.Text.Trim());
                comm.Parameters.AddWithValue("@password", TextPwd.Text.Trim());
                int result = comm.ExecuteNonQuery();

                if (result > 0)
                {
                    Session["uEmail"] = TextEmail.Text.Trim();
                    Session["uPwd"] = TextPwd.Text.Trim();
                    Session["uName"] = TextName.Text.Trim();
                    Session["uSex"] = ddlSex.SelectedValue.ToString();
                    Session["uTel"] = TextTel.Text.Trim();
                    Session["uAddress"] = TextAddress.Text.Trim();
                    Response.Write("Record has been updated!!!");
                }
                conn.Close();

            }   
        }

        // 判断email是否已经存在
        // 传入参数email  需要查的参数
        // 返回值true：此email已经存在
        // 返回值false：此email不存在
        public Boolean IsEmailExists(string email)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
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