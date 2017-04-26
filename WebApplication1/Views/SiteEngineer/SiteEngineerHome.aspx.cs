using System;
using System.Web.UI;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class SiteEngineerHome : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/CreateClient.aspx");
        }

        protected void ViewClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/ViewAllClients.aspx");
        }

        protected void CreateIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/CreateIntervention.aspx");
        }

        protected void ViewInterventions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/ViewInterventions.aspx");
        }

        protected void ViewInterventionbyClients_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/ViewInterventionbyClient.aspx");
        }

        protected void ViewAllClientsInSameDistrict_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/ViewAllClientsInSameDistrict.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Views/ChangePassword.aspx");
        }
   
    }
}