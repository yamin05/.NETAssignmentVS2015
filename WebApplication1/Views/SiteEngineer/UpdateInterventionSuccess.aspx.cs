using System;
using System.Web.UI;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class UpdateInterventionSuccess : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/SiteEngineer/ViewInterventions.aspx");
        }
    }
}