using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Exceptions;
using WebApplication1.Helpers;

namespace WebApplication1.Views.Accountant
{
    public partial class MonthlyCostForDistrict : System.Web.UI.Page
    {
        private ViewReportHelper viewReportHelper = new ViewReportHelper("CustomDatabase");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            District.DataSource = CreateDataSourceForDistrict();
            District.DataTextField = "StatusName";
            District.DataValueField = "StatusValue";
            District.DataBind();
            District.Visible = true;
            }
        }

        ICollection CreateDataSourceForDistrict()
        {
            var list = viewReportHelper.GetDistrictForUser();
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("StatusName", typeof(string)));
            datatable.Columns.Add(new DataColumn("StatusValue", typeof(int)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRowForDistrict(row.Key, row.Value, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRowForDistrict(string districtName, int districtValue, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = districtName;
            datarow[1] = districtValue;
            return datarow;
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            GridView.DataSource = CreateDataSourceForGridView(District.SelectedValue);
            GridView.DataBind();
            GridView.Columns[0].Visible = false;
            Label2.Visible = true;
        }


        ICollection CreateDataSourceForGridView(string districtId)
        {
            var list = viewReportHelper.ViewMonthlyCostForDistrict(districtId);
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("DistrictId", typeof(string)));
            datatable.Columns.Add(new DataColumn("DistrictName", typeof(string)));
            datatable.Columns.Add(new DataColumn("Month", typeof(string)));
            datatable.Columns.Add(new DataColumn("MonthlyCosts", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("MonthlyHours", typeof(decimal)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRowForGridView(row.DistrictId, row.DistrictName, row.Month, row.MonthlyCosts, row.MonthlyHours, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRowForGridView(string DistrictId, string DistrictName, string Month, decimal MonthlyCosts, decimal MonthlyHours, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = DistrictId;
            datarow[1] = DistrictName;
            datarow[2] = Month;
            datarow[3] = MonthlyCosts;
            datarow[4] = MonthlyHours;
            return datarow;
        }
    }
}