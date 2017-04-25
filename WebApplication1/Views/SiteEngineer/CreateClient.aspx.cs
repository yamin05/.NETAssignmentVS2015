using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class CreateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NewClientSubmit_Click(object sender, EventArgs e)
        {
            string clientName;
            string clientLocation;
            int clientDistrictint;
            clientName = NewClientName.Text;
            clientLocation = NewClientAddress.Text;
            clientDistrictint = Convert.ToInt32(NewClientDistrict1.SelectedValue);
            string conString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20170404072835.mdf;Initial Catalog=aspnet-WebApplication1-20170404072835;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(conString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into clients values ('" + clientName + "','" + clientLocation + "','" + clientDistrictint + "')", myConnection);
            int count = cmd.ExecuteNonQuery();
            if(count>0)
            {
                Response.Redirect("~/Views/SiteEngineer/ViewClient.aspx");
            }
            else
            {
                Response.Redirect("~/Views/SiteEngineer/CreateClient.aspx");
            }
            myConnection.Close();
        }
    }
}