using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class SiteEngineerHome : System.Web.UI.Page
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
            Response.Redirect("~/Views/SiteEngineer/ViewClient.aspx");
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

        protected void ViewClientDistrict_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/ViewClientbyDistrict.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Views/ChangePassword.aspx");
        }
   
    }
}