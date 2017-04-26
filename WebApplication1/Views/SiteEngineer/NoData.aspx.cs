using System;
using System.Web.UI;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class NoData : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Message.Text = Request.QueryString["message"];
            }
        }
    }
}