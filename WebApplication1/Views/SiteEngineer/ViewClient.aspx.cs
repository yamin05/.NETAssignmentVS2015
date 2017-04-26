using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Helpers;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class ViewClient : Page
    {
        private ViewClientHelper viewClientHelper = new ViewClientHelper("CustomDatabase"); 
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = CreateDataSource();
                GridView.DataBind();
            }
        }

        ICollection CreateDataSource()
        {
            var list = viewClientHelper.GetAllClients();
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("ClientId", typeof(int)));
            datatable.Columns.Add(new DataColumn("ClientName", typeof(string)));
            datatable.Columns.Add(new DataColumn("ClientLocation", typeof(string)));
            datatable.Columns.Add(new DataColumn("ClientDistrict", typeof(string)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRow(row.ClientId, row.ClientName, row.ClientLocation, Enum.GetName(typeof(Districts), row.ClientDistrict), datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRow(int clientId, string clientName, string clientLocation, string clientDistrict, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = clientId;
            datarow[1] = clientName;
            datarow[2] = clientLocation;
            datarow[3] = clientDistrict;
            return datarow;
        }

        protected void AddClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/CreateClient.aspx");
        }
    }
}