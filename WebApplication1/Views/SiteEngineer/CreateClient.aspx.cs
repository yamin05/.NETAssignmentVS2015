using System;
using System.Web;
using System.Web.UI;
using System.Collections;
using WebApplication1.Helpers;
using Microsoft.AspNet.Identity;
using System.Data;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class CreateClient : Page
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
            else
            {
                ErrorMessage.Visible = false;
            }
        }

        ICollection CreateDataSource()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var row = createClientHelper.GetDistrictsForSiteManager(userId);
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("District", typeof(string)));
            datatable.Columns.Add(new DataColumn("DistrictInt", typeof(string)));          
            datatable.Rows.Add(CreateRow(Enum.GetName(typeof(Districts), row) , row, datatable));
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRow(string text, int value, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = text;
            datarow[1] = value;
            return datarow;
        }

        protected void NewClientSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                createClientHelper.CreateClient(NewClientName.Text, NewClientAddress.Text, Convert.ToInt32(NewClientDistrict.SelectedValue));
                Response.Redirect("~/Views/SiteEngineer/CreateClientSuccess.aspx");
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }
    }
}