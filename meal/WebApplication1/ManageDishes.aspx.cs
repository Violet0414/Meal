using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace WebApplication1
{
    public partial class mDishes : System.Web.UI.Page
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
        }


        protected void Upload_Click(object sender, EventArgs e)
        {

	    //将菜品图片的存储路径赋值给path
            string path = Server.MapPath("~/image/dishes/");
            if (File.HasFile)
            {
                try
                {
                    // 上传图片，将图片存入image/dishes/目录下
                    File.PostedFile.SaveAs(path + File.FileName);

	   // 判断输入框内的信息是否不为空
                    if (File.FileName.ToString() == "" || dishPrice.Text.Trim() == "" || selectList.DataValueField == "" || dishName.Text.Trim() == "")
                    {
                        Response.Write("<script language=javascript>alert('Please fill in the dish information completely!');</" + "script>");
                    }
                    else
                    {
                        string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
                        SqlConnection conn = new SqlConnection(connStr);
                        conn.Open();


			// 获取展示页面输入的菜品信息并插入菜品表
                        string sqlQuery =
                        "insert into dishes (sid,name,price,image) values (@type,@name,@price,@fname);";
                        SqlCommand comm = new SqlCommand(sqlQuery, conn);
                        comm.Parameters.AddWithValue("@fname", File.FileName);
                        comm.Parameters.AddWithValue("@name", dishName.Text.Trim());
                        comm.Parameters.AddWithValue("@price", dishPrice.Text.Trim());
                        comm.Parameters.AddWithValue("@type", selectList.SelectedValue);
                        int result = comm.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect(Request.Url.ToString());
                        Response.Write("<script language=javascript>alert('Dishes uploaded successfully！');</" + "script>");
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                //Response.Write("<script language=javascript>alert('Please select a file to upload!');</" + "script>");
            }
        }

    }
}