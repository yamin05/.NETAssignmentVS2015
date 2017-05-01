using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Helpers;

namespace WebApplication1.Views.Accountant
{
    public partial class AverageCostByEngineer : System.Web.UI.Page
    {
        private ViewReportHelper viewReportHelper = new ViewReportHelper("CustomDatabase");


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = CreateDataSourceForGridView();
                GridView.DataBind();
                GridView.Columns[0].Visible = false;

            }
            else
            {
                ErrorMessage.Visible = false;
            }

        }

        ICollection CreateDataSourceForGridView()
        {
            var list = viewReportHelper.ViewAverageCostsByEngineer();
            //if (list.Count == 0)
            //{
            //    Response.Redirect("~/Views/SiteEngineer/NoData.aspx?message=" + "No Interventions Have Been Created By You");
            //}
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("UserId", typeof(string)));
            datatable.Columns.Add(new DataColumn("UserName", typeof(string)));
            datatable.Columns.Add(new DataColumn("RoleName", typeof(string)));
            datatable.Columns.Add(new DataColumn("AverageCosts", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("AverageHours", typeof(decimal)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRowForGridView(row.UserId, row.UserName, row.RoleName, row.AverageCosts, row.AverageHours, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRowForGridView(string UserId, string UserName, string RoleName, decimal AverageCosts, decimal AverageHours, DataTable datatable)
        {

            DataRow datarow = datatable.NewRow();
            datarow[0] = UserId;
            datarow[1] = UserName;
            datarow[2] = RoleName;
            datarow[3] = AverageCosts;
            datarow[4] = AverageHours;
            return datarow;
        }
    }
}