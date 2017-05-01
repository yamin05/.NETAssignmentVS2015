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
    public partial class CostByDistrict : System.Web.UI.Page
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
            var list = viewReportHelper.ViewCostsByDistrict();
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("DistrictId", typeof(int)));
            datatable.Columns.Add(new DataColumn("DistrictName", typeof(string)));
            datatable.Columns.Add(new DataColumn("Costs", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("Hours", typeof(decimal)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRowForGridView(row.DistrictId, row.DistrictName, row.Costs, row.Hours, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRowForGridView(string DistrictId, string DistrictName, decimal Costs, decimal Hours, DataTable datatable)
        {

            DataRow datarow = datatable.NewRow();
            datarow[0] = DistrictId;
            datarow[1] = DistrictName;
            datarow[2] = Costs;
            datarow[3] = Hours;
            return datarow;
        }
    }
}