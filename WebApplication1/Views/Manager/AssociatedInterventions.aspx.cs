using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Helpers;
using Microsoft.AspNet.Identity;
using System.Data;
using WebApplication1.Models;
using WebApplication1.Extensions;

namespace WebApplication1.Views.Manager
{
    public partial class AssociatedInterventions : System.Web.UI.Page
    {
        private ListInterventionsHelper listInterventions = new ListInterventionsHelper("CustomDatabase");
        protected void Page_Load(object sender, EventArgs e)
        {
            Grid.DataSource = CreateSource();
            Grid.DataBind();

        }
        public DataTable CreateSource()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            List<ListInterventionForManager> AssociatedInterList = new List<ListInterventionForManager>();
            AssociatedInterList = listInterventions.ListOfAssociatedIntrevention(userId).ToList();
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("District", typeof(string)));
            datatable.Columns.Add(new DataColumn("ClientDistrict", typeof(string)));
            datatable.Columns.Add(new DataColumn("ClientName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionTypeName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionHours", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("InterventionCost", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
            datatable.Columns.Add(new DataColumn("Status", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionId", typeof(int)));
            foreach (var row in AssociatedInterList)
            {
                datatable.Rows.Add(CreateRow(Enum.GetName(typeof(Districts), row.District), Enum.GetName(typeof(Districts), row.ClientDistrict), row.ClientName, row.InterventionTypeName, row.InterventionHours, row.InterventionCost, row.CreateDate, Enum.GetName(typeof(Status), row.Status), row.InterventionId, datatable));
            }

            return datatable;
        }


        DataRow CreateRow(string district, string clientdistrict, string clientName, string InterventionName, decimal hours, decimal cost, DateTime date, string status, int interventionid, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = district;
            datarow[1] = clientdistrict;
            datarow[2] = clientName;
            datarow[3] = InterventionName;
            datarow[4] = hours;
            datarow[5] = cost;
            datarow[6] = date;
            datarow[7] = status;
            datarow[8] = interventionid;
            return datarow;
        }
    }
}