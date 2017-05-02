using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Exceptions;
using WebApplication1.Helpers;
using WebApplication1;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class ViewInterventions : Page
    {
        private ListInterventionsHelper listInterventionsHelper = new ListInterventionsHelper("CustomDatabase");
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataSource = CreateDataSourceForGridView();
                GridView.DataBind();
                GridView.Columns[6].Visible = false;
                QMInfoButton.Visible = false;

            } else
            {
                ErrorMessage.Visible = false;
                GridView_SelectedIndexChanged1(this, EventArgs.Empty);
            }

        }

        ICollection CreateDataSourceForGridView()
        {
            var list = listInterventionsHelper.GetInterventionsForUser();
            if (list.Count == 0)
            {
                Response.Redirect("~/Views/SiteEngineer/NoData.aspx?message=" + "No Interventions Have Been Created By You");
            }
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("ClientName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionTypeName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionHours", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("InterventionCost", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
            datatable.Columns.Add(new DataColumn("Status", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionId", typeof(int)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRowForGridView(row.ClientName, row.InterventionId, row.InterventionTypeName, row.InterventionHours, row.InterventionCost, row.CreateDate, Enum.GetName(typeof(Status), row.Status), datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRowForGridView(string clientName, int intid, string typeName, decimal hours, decimal cost, DateTime date, string status, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = clientName;
            datarow[1] = typeName;
            datarow[2] = hours;
            datarow[3] = cost;
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
                    Sts.DataSource = CreateDataSourceForStatus();
                    Sts.DataTextField = "StatusName";
                    Sts.DataValueField = "StatusValue";
                    Sts.DataBind();
                    Sts.Visible = true;
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
                    Response.Redirect("~/Views/SiteEngineer/EditQMInfoIntervention.aspx?intid=" + GridView.SelectedRow.Cells[7].Text);
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
                changeStatusHelper.ChangeStatus(GridView.SelectedRow.Cells[7].Text, GridView.SelectedRow.Cells[6].Text, Sts.SelectedValue);
                Response.Redirect("~/Views/SiteEngineer/UpdateInterventionSuccess.aspx");
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }
        
        protected void GridView_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (GridView.SelectedRow != null && !(GridView.SelectedRow.Cells[6].Text.Equals(Status.Proposed.ToString())))
            {
                QMInfoButton.Visible = true;
            }
            else
            {
                QMInfoButton.Visible = false;
            }
        }
    }
}