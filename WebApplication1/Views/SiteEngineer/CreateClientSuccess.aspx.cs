using System;
using System.Web.UI;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class CreateClientSuccess : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/ViewAllClients.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/ViewAllClientsInSameDistrict.aspx");
        }
    }
}