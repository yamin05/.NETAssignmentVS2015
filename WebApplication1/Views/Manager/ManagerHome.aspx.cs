using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1.Views.Manager
{
    public partial class ManagerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ChangePassword.aspx");
        }
        protected void Manager_Intervention_List_Click(object sender, EventArgs e)
        {
            //string conString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20170404072835.mdf;Initial Catalog=aspnet-WebApplication1-20170404072835;Integrated Security=True";
            //SqlConnection myConnection = new SqlConnection(conString);
            //myConnection.Open();
            //SqlCommand cmd = new SqlCommand("Select InterventionTypeId, InterventionCost, InterventionHours,Status from Interventions;");
            //var result = cmd.ExecuteReader();
            //SqlCommand cmd1 = new SqlCommand("Select InterventionTypeId, InterventionCost, InterventionHours,Status from Interventions;");
            //var result1 = cmd1.ExecuteReader();
            //while (result.Read())
            //{
                
            //}
            Response.Redirect("~/Views/Manager/ListInterventions.aspx");
        }
    }
    
}