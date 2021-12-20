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
    public partial class Default : System.Web.UI.Page
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
            string connStr = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();


            string sqlQuery = "select top 3 did,dishes.name name,sum from dishes " +
                "left join (select top 3 did, sum(number) sum from orders group by did) uorders " +
                "on dishes.id = did order by sum desc; ";
            SqlCommand comm = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            
            this.dishesList.DataSource = reader;
            this.dishesList.DataBind();
            reader.Close();
            conn.Close();
        }
    }
}