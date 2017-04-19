using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Views.Admin
{
    public partial class AdminHome : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ChangePassword.aspx");
        }
    }
}