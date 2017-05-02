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
using WebApplication1;

namespace WebApplication1.Views.Accountant
{
    public partial class UsersList : System.Web.UI.Page
    {
        private ViewUsersHelper viewUsersHelper = new ViewUsersHelper("CustomDatabase");
        private ChangeDistrictsHelper changeDistrictsHelper = new ChangeDistrictsHelper("CustomDatabase");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = CreateDataSourceForGridView();
                GridView.DataBind();
                GridView.Columns[0].Visible = false;
                GridView.Columns[5].Visible = false;
            }
            else
            {
                ErrorMessage.Visible = false;
            }

        }

        ICollection CreateDataSourceForGridView()
        {
            var list = viewUsersHelper.GetAllUsers();

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
                datatable.Rows.Add(CreateRowForGridView(row.UserId, row.UserName, row.RoleName, row.MaximumCost, row.MaximumHours, row.District, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRowForGridView(string UserId, string UserName, string RoleName, decimal MaximumCost, decimal MaximumHours, int District, DataTable datatable)
        {
            
            DataRow datarow = datatable.NewRow();
            datarow[0] = UserId;
            datarow[1] = UserName;
            datarow[2] = RoleName;
            datarow[3] = MaximumCost;
            datarow[4] = MaximumHours;
            datarow[5] = District;
            datarow[6] = GetDistrictName(District);
            return datarow;
        }

        private string GetDistrictName(int DistrictNumber)
        {
            string DistrictName = "";
            if (DistrictNumber == (int)Districts.Urban_Indonesia)
            {
                DistrictName = "Urban_Indonesia".Replace("_", " ");
            }
            if (DistrictNumber == (int)Districts.Rural_Indonesia)
            {
                DistrictName = "Rural_Indonesia".Replace("_", " ");
            }
            if (DistrictNumber == (int)Districts.Urban_Papua_New_Guinea)
            {
                DistrictName = "Urban_Papua_New_Guinea".Replace("_", " ");
            }
            if (DistrictNumber == (int)Districts.Rural_Papua_New_Guinea)
            {
                DistrictName = "Rural_Papua_New_Guinea".Replace("_", " ");
            }
            if (DistrictNumber == (int)Districts.Sydney)
            {
                DistrictName = "Sydney".Replace("_", " ");
            }
            if (DistrictNumber == (int)Districts.Rural_New_South_Wales)
            {
                DistrictName = "Rural_New_South_Wales".Replace("_", " ");
            }

            return DistrictName;

        }

        protected void ChangeDistrict_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridView.SelectedIndex == -1)
                {
                    throw new ValueNotSelectedException();
                }
                else
                {
                    District.DataSource = CreateDataSourceForDistrict();
                    District.DataTextField = "StatusName";
                    District.DataValueField = "StatusValue";
                    District.DataBind();
                    District.Visible = true;
                    Confirm.Visible = true;
                    Cancel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }


        ICollection CreateDataSourceForDistrict()
        {
            var list = changeDistrictsHelper.GetDistrictForUser();
            if (list.Count == 0)
            {
                throw new CannotEditStatusException();
            }
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
            try
            {

                var changeDistrictsHelper = new ChangeDistrictsHelper("CustomDatabase");
                changeDistrictsHelper.ChangeDistricts(GridView.SelectedRow.Cells[1].Text, GridView.SelectedRow.Cells[6].Text, Convert.ToInt32(District.SelectedValue));
                Response.Redirect("~/Views/Accountant/UsersList.aspx", false);
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;

            }
        }

    }
}