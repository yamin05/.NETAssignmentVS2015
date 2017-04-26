using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Helpers;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class ViewInterventionsForClient : Page
    {
        private ListInterventionsHelper listInterventionsHelper = new ListInterventionsHelper("CustomDatabase");

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
            var list = listInterventionsHelper.GetInterventionsForClient(Request.QueryString["clientid"]);
            if (list.Count == 0)
            {
                Response.Redirect("~/Views/SiteEngineer/NoData.aspx?message=" + "No Interventions Created for this Client");
            }
            ClientName.Text = list.First().ClientName;
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("InterventionTypeName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionHours", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("InterventionCost", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
            datatable.Columns.Add(new DataColumn("Status", typeof(string)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRow(row.InterventionTypeName, row.InterventionHours, row.InterventionCost, row.CreateDate, Enum.GetName(typeof(Status), row.Status), datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRow(string typeName, decimal hours, decimal cost, DateTime date, string status, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = typeName;
            datarow[1] = hours;
            datarow[2] = cost;
            datarow[3] = date;
            datarow[4] = status;
            return datarow;
        }
    }
}