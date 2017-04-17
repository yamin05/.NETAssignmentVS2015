using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class EngineerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateClient_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/SiteEngineer/CreateClient.aspx");
        }

        protected void ViewClient_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/SiteEngineer/ViewClient.aspx");
        }

        protected void CreateIntervention_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/SiteEngineer/CreateIntervention.aspx");
        }

        protected void ViewInterventions_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/SiteEngineer/ViewInterventions.aspx");
        }

        protected void ViewInterventionbyClients_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/SiteEngineer/ViewInterventionbyClient.aspx");
        }

        protected void ViewClientDistrict_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Views/SiteEngineer/ViewClientbyDistrict.aspx");
        }
    }
}