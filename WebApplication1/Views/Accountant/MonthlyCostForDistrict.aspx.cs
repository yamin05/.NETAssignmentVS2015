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
            District.DataSource = CreateDataSourceForDistrict();
            District.DataTextField = "StatusName";
            District.DataValueField = "StatusValue";
            District.DataBind();
            District.Visible = true;

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

             Response.Redirect("~/Views/Accountant/MonthlyCostForDistrict.aspx?district=999", false);
        }

    }
}