using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class CreateIntervention : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NewInterventionSubmit_Click(object sender, EventArgs e)
        {
            string interventionName;
            decimal hours;
            decimal cost;

            interventionName = NewInterventionName.Text;
            hours = Convert.ToDecimal (NewInterventionHours.Text);
            cost = Convert.ToDecimal(NewInterventionCost.Text);
            string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-WebApplication1-20170404072835;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection myConnection = new SqlConnection(conString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into interventiontype values ('" + interventionName + "','" + hours + "','" + cost + "')", myConnection);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Response.Redirect("~/Views/SiteEngineer/Viewinterventions.aspx");
            }
            else
            {
                Response.Redirect("~/Views/SiteEngineer/CreateIntervention.aspx");
            }
            myConnection.Close();
        }
    }
}