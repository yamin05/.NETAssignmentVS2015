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
    public partial class TotalCostByEngineer : System.Web.UI.Page
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
            var list = viewReportHelper.ViewTotalCostsByEngineer();
          
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("UserId", typeof(string)));
            datatable.Columns.Add(new DataColumn("UserName", typeof(string)));
            datatable.Columns.Add(new DataColumn("RoleName", typeof(string)));
            datatable.Columns.Add(new DataColumn("TotalCosts", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("TotalHours", typeof(decimal)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRowForGridView(row.UserId, row.UserName, row.RoleName, row.TotalCosts, row.TotalHours, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRowForGridView(string UserId, string UserName, string RoleName, decimal TotalCosts, decimal TotalHours, DataTable datatable)
        {

            DataRow datarow = datatable.NewRow();
            datarow[0] = UserId;
            datarow[1] = UserName;
            datarow[2] = RoleName;
            datarow[3] = TotalCosts;
            datarow[4] = TotalHours;
            return datarow;
        }
    }
}