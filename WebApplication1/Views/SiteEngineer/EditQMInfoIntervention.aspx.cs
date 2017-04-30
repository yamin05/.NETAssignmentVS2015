using System;
using System.Web;
using System.Web.UI;
using System.Collections;
using WebApplication1.Helpers;
using Microsoft.AspNet.Identity;
using System.Data;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class EditQMInfoIntervention : Page
    {
        private EditQMInfoHelper editQMInfoHelper = new EditQMInfoHelper("CustomDatabase");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["intid"] = Request.QueryString["intid"];
                GridView.DataSource = CreateDataSource();
                GridView.DataBind();
                GridView.Columns[0].Visible = false;
            }
            else
            {
                ErrorMessage.Visible = false;
            }
        }

        ICollection CreateDataSource()
        {
            var list = editQMInfoHelper.GetAllPreviousUpdates(ViewState["intid"].ToString());
            if (list.Count == 0)
            {
                GridView.Visible = false;
                PreviousUpdatesLabel.Text = "No Previous Updates Found";
            }
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("InterventionUpdateId", typeof(int)));
            datatable.Columns.Add(new DataColumn("Condition", typeof(int)));
            datatable.Columns.Add(new DataColumn("ModifyDate", typeof(DateTime)));
            datatable.Columns.Add(new DataColumn("InterventionCommments", typeof(string)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRow(row.InterventionUpdateId, row.Condition, row.ModifyDate, row.InterventionComments, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRow(int interventionUpdateId, int condition, DateTime date, string comments, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = interventionUpdateId;
            datarow[1] = condition;
            datarow[2] = date;
            datarow[3] = comments;
            return datarow;
        }

        protected void NewClientSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                editQMInfoHelper.updateQMInfo(ViewState["intid"].ToString() , Comments.Text , Condition.Text);
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