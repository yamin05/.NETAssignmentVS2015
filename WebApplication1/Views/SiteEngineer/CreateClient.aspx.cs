using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using WebApplication1.Helpers;
using Microsoft.AspNet.Identity;
using System.Data;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class CreateClient : System.Web.UI.Page
    {
        private CreateClientHelper createClientHelper = new CreateClientHelper("CustomDatabase");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewClientDistrict.DataSource = CreateDataSource();
                NewClientDistrict.DataTextField = "District";
                NewClientDistrict.DataValueField = "DistrictInt";
                NewClientDistrict.DataBind();
                NewClientDistrict.SelectedIndex = 0;
            }
        }

        ICollection CreateDataSource()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            // Create a table to store data for the DropDownList control.
            var list = createClientHelper.GetDistrictsForSiteManager(userId);
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("District", typeof(string)));
            datatable.Columns.Add(new DataColumn("DistrictInt", typeof(String)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRow(Enum.GetName(typeof(Districts), row) , row, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;

        }

        DataRow CreateRow(string Text, int Value, DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr[0] = Text;
            dr[1] = Value;
            return dr;
        }

        protected void NewClientSubmit_Click(object sender, EventArgs e)
        {
            createClientHelper.CreateClient(NewClientName.Text, NewClientAddress.Text, Convert.ToInt32(NewClientDistrict.SelectedValue));
            //string conString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20170404072835.mdf;Initial Catalog=aspnet-WebApplication1-20170404072835;Integrated Security=True";
            //SqlConnection myConnection = new SqlConnection(conString);
            //myConnection.Open();
            //SqlCommand cmd = new SqlCommand("insert into clients values ('" + clientName + "','" + clientLocation + "','" + clientDistrictint + "')", myConnection);
            //int count = cmd.ExecuteNonQuery();
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