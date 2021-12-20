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
    public partial class mSpecies : System.Web.UI.Page
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
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


	    // 将页面内填入的菜品分类插入分类表中
            string sqlQuery =
            "insert into species (name) values (@name);";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            comm.Parameters.AddWithValue("@name", sName.Text.Trim());

            int result = comm.ExecuteNonQuery();
            conn.Close();

            Response.Redirect(Request.Url.ToString());
            Response.Write("<script language=javascript>alert('Upload classification succeeded！');</script>");
        }
    }
}