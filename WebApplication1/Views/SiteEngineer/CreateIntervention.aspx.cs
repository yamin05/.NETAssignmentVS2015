using System;
using System.Web.UI;
using System.Data.SqlClient;
using WebApplication1.Helpers;
using System.Collections;
using System.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class CreateIntervention : Page
    {
        private CreateInterventionHelper createInterventionHelper = new CreateInterventionHelper("CustomDatabase");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InterventionType.DataSource = CreateInterventionTypeDataSource();
                InterventionType.DataTextField = "InterventionType";
                InterventionType.DataValueField = "InterventionTypeId";
                InterventionType.DataBind();
                InterventionType.SelectedIndex = 0;

                ClientName.DataSource = CreateClientNameDataSource();
                ClientName.DataTextField = "ClientName";
                ClientName.DataValueField = "ClientId";
                ClientName.DataBind();
                ClientName.SelectedIndex = 0;
            }
        }

        ICollection CreateInterventionTypeDataSource()
        {
            var list = createInterventionHelper.GetInterventionTypes();
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("InterventionType", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionTypeId", typeof(int)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRow(row.InterventionTypeName , row.InterventionTypeId , datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        ICollection CreateClientNameDataSource()
        {
            var list = createInterventionHelper.GetClientNames();
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("ClientName", typeof(string)));
            datatable.Columns.Add(new DataColumn("ClientId", typeof(int)));
            foreach (var row in list)
            {
                datatable.Rows.Add(CreateRow(row.ClientName, row.ClientId, datatable));
            }
            DataView dataview = new DataView(datatable);
            return dataview;
        }

        DataRow CreateRow(string text, int value, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = text;
            datarow[1] = value;
            return datarow;
        }

        protected void NewInterventionSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                createInterventionHelper.CreateIntervention(int.Parse(InterventionType.SelectedValue), int.Parse(ClientName.SelectedValue),
                    NewInterventionHours.Text, NewInterventionCost.Text);
                Response.Redirect("~/Views/SiteEngineer/CreateInterventionSuccess.aspx");
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }
    }
}