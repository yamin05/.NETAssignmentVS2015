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
    public partial class UsersList : System.Web.UI.Page
    {
        private ViewUsersHelper viewUsersHelper = new ViewUsersHelper("CustomDatabase", "DefaultConnection");
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = CreateDataSourceForGridView();
                GridView.DataBind();
                //GridView.Columns[6].Visible = false;
            }
            else
            {
                ErrorMessage.Visible = false;
            }

        }

        ICollection CreateDataSourceForGridView()
        {
            var list = viewUsersHelper.GetAllUsers();
            if (list.Count == 0)
            {
                Response.Redirect("~/Views/SiteEngineer/NoData.aspx?message=" + "No Interventions Have Been Created By You");
            }
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("UserId", typeof(string)));
            datatable.Columns.Add(new DataColumn("UserName", typeof(string)));
            datatable.Columns.Add(new DataColumn("RoleName", typeof(string)));
            datatable.Columns.Add(new DataColumn("MaximumCost", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("MaximumHours", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("District", typeof(int)));
            datatable.Columns.Add(new DataColumn("DistrictName", typeof(string)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRowForGridView(row.UserId, row.UserName, row.RoleName, row.MaximumCost, row.MaximumHours, row.District, row.DistrictName, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRowForGridView(string UserId, string UserName, string RoleName, decimal MaximumCost, decimal MaximumHours, int District, string DistrictName, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = UserId;
            datarow[1] = UserName;
            datarow[2] = RoleName;
            datarow[3] = MaximumCost;
            datarow[4] = MaximumHours;
            datarow[5] = District;
            datarow[6] = DistrictName;
            return datarow;
        }
    }
}