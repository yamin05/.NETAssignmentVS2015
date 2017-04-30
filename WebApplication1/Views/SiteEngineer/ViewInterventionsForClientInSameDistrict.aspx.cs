using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Exceptions;
using WebApplication1.Helpers;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class ViewInterventionsForClientInSameDistrict : Page
    {
        private ListInterventionsHelper listInterventionsHelper = new ListInterventionsHelper("CustomDatabase");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = CreateDataSource();
                GridView.DataBind();
                GridView.Columns[6].Visible = false;
            }
            else
            {
                ErrorMessage.Visible = false;
            }
        }
        ICollection CreateDataSource()
        {
            var list = listInterventionsHelper.GetInterventionsForClientInSameDistrict(Request.QueryString["clientid"]);
            if (list.Count == 0)
            {
                Response.Redirect("~/Views/SiteEngineer/NoData.aspx?message=" + "No Interventions Created for this Client");
            }
            ClientName.Text = list.First().ClientName;
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("InterventionTypeName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionHours", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("InterventionCost", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("CreatedBy", typeof(string)));
            datatable.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
            datatable.Columns.Add(new DataColumn("Status", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionId", typeof(int)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRow(row.InterventionTypeName, row.InterventionId, row.InterventionHours, row.InterventionCost, row.UserName,
                    row.CreateDate, Enum.GetName(typeof(Status), row.Status), datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRow(string typeName, int intid, decimal hours, decimal cost, string createdBy, DateTime date, string status, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = typeName;
            datarow[1] = hours;
            datarow[2] = cost;
            datarow[3] = createdBy;
            datarow[4] = date;
            datarow[5] = status;
            datarow[6] = intid;
            return datarow;
        }

        protected void ChangeState_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridView.SelectedIndex == -1)
                {
                    throw new ValueNotSelectedException();
                }
                else
                {
                    Status.DataSource = CreateDataSourceForStatus();
                    Status.DataTextField = "StatusName";
                    Status.DataValueField = "StatusValue";
                    Status.DataBind();
                    Status.Visible = true;
                    UpdateButton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }

        protected void EditQMInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridView.SelectedIndex == -1)
                {
                    throw new ValueNotSelectedException();
                }
                else
                {
                    Response.Redirect("~/Views/SiteEngineer/EditQMInfoIntervention.aspx?intid=" + Convert.ToInt32(GridView.SelectedRow.Cells[7].Text));
                }
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }

        ICollection CreateDataSourceForStatus()
        {
            var list = listInterventionsHelper.GetPossibleStatusUpdateForIntervention(GridView.SelectedRow.Cells[6].Text);
            if (list.Count == 0)
            {
                throw new CannotEditStatusException();
            }
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("StatusName", typeof(string)));
            datatable.Columns.Add(new DataColumn("StatusValue", typeof(int)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRowForStatus(row.Key, row.Value, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRowForStatus(string statusName, int statusValue, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = statusName;
            datarow[1] = statusValue;
            return datarow;
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var changeStatusHelper = new ChangeStatusHelper("CustomDatabase");
                changeStatusHelper.ChangeStatus(GridView.SelectedRow.Cells[7].Text, GridView.SelectedRow.Cells[6].Text, Status.SelectedValue);
                Response.Redirect("~/Views/SiteEngineer/UpdateInterventionSuccess.aspx");
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }
    }
}