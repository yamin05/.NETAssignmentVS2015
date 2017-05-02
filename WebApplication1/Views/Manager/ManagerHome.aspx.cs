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
            Response.Redirect("~/Views/Manager/ListInterventions.aspx");
        }
        protected void Manager_Assoiciated_Interventions(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Manager/AssociatedInterventions.aspx");
        }
    }
    
}