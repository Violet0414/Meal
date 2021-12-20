using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class PersonalMessage : System.Web.UI.Page
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
            this.TextName.Text = Session["uName"].ToString();
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
}