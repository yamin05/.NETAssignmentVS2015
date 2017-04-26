using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Helpers;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class ViewInterventions : Page
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
            var list = listInterventionsHelper.GetInterventionsForUser(HttpContext.Current.User.Identity.GetUserId());
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("ClientName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionTypeName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionHours", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("InterventionCost", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
            datatable.Columns.Add(new DataColumn("Status", typeof(string)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRow(row.ClientName, row.InterventionTypeName, row.InterventionHours, row.InterventionCost, row.CreateDate, Enum.GetName(typeof(Status), row.Status), datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRow(string clientName, string typeName, decimal hours, decimal cost, DateTime date, string status, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = clientName;
            datarow[1] = typeName;
            datarow[2] = hours;
            datarow[3] = cost;
            datarow[4] = date;
            datarow[5] = status;
            return datarow;
        }
    }
}