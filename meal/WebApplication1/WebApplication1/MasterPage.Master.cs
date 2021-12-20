using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.uName.Text = Session["uName"].ToString();
            }
        }

        protected void singOutBtn_Click(object sender, EventArgs e)
        {
            Session["uId"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}