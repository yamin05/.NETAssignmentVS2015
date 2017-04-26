using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using WebApplication1.Exceptions;
using WebApplication1.Helpers;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class ViewAllClientsInSameDistrict : Page
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
            var list = viewClientHelper.GetAllClientsInSameDistrict();
            if (list.Count == 0)
            {
                Response.Redirect("~/Views/SiteEngineer/NoData.aspx?message=" + "No Clients Have Been Created In This District");
            }
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

        protected void ViewAssociatedInterventions_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridView.SelectedIndex == -1)
                {
                    throw new ValueNotSelectedException();
                }
                else
                {
                    Response.Redirect("~/Views/SiteEngineer/ViewInterventionsForClientInSameDistrict.aspx?clientId=" + Convert.ToInt32(GridView.SelectedRow.Cells[1].Text));
                }
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }
    }
}