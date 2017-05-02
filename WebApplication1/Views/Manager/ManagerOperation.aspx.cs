using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Helpers;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;
using WebApplication1.Exceptions;

namespace WebApplication1.Views.Manager
{
    public partial class ManagerOperation : System.Web.UI.Page
    {
        private ListInterventionsHelper listInterventions = new ListInterventionsHelper("CustomDatabase");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid.DataSource = CreateSource();
                Grid.DataBind();
                backtolist1.Visible = false;
            }
        }
        public DataTable CreateSource()
        {
            string interventionId = Request.QueryString["ID"];
            int interid = Convert.ToInt32(interventionId);
            var userId = HttpContext.Current.User.Identity.GetUserId();
            List<ListInterventionForManager> InterList = new List<ListInterventionForManager>();
            InterList = listInterventions.ListOfPropInterventions(userId, interid).ToList();
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("District", typeof(string)));
            datatable.Columns.Add(new DataColumn("ClientDistrict", typeof(string)));
            datatable.Columns.Add(new DataColumn("ClientName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionTypeName", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionHours", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("InterventionCost", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
            datatable.Columns.Add(new DataColumn("Status", typeof(string)));
            datatable.Columns.Add(new DataColumn("InterventionId", typeof(int)));
            foreach (var row in InterList)
            {
                datatable.Rows.Add(CreateRow(Enum.GetName(typeof(Districts), row.District), Enum.GetName(typeof(Districts), row.ClientDistrict), row.ClientName, row.InterventionTypeName, row.InterventionHours, row.InterventionCost, row.CreateDate, Enum.GetName(typeof(Status), row.Status), row.InterventionId, datatable));
            }

            return datatable;
        }
        DataRow CreateRow(string district, string clientdistrict, string clientName, string InterventionName, decimal hours, decimal cost, DateTime date, string status, int interventionid, DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = district;
            datarow[1] = clientdistrict;
            datarow[2] = clientName;
            datarow[3] = InterventionName;
            datarow[4] = hours;
            datarow[5] = cost;
            datarow[6] = date;
            datarow[7] = status;
            datarow[8] = interventionid;
            return datarow;
        }

        protected void Approve(object sender, EventArgs e)
        {
            string interventionId = Request.QueryString["ID"];
            int interid = Convert.ToInt32(interventionId);
            string userid = HttpContext.Current.User.Identity.GetUserId();
            string oldstatus = Request.QueryString["Status"];
            int newstatus = (int)Status.Approved;
            int old_status = (int)((Status)Enum.Parse(typeof(Status), oldstatus));
            listInterventions.ApproveIntervention(interid, old_status, newstatus, userid);
            Grid.DataSource = CreateSource();
            Grid.DataBind();
            approve.Visible = false;
            cancel.Visible = true;
            backtolist.Visible = false;
            backtolist1.Visible = true;
            Label2.Text = "The Intervention has been approved";
        }

        protected void Cancel(object sender, EventArgs e)
        {
            string interventionId = Request.QueryString["ID"];
            int interid = Convert.ToInt32(interventionId);
            listInterventions.CancelIntervention(interid);
            Grid.DataSource = CreateSource();
            Grid.DataBind();
            approve.Visible = false;
            cancel.Visible = false;
            backtolist.Visible = false;
            backtolist1.Visible = true;
            Label2.Text = "The Intervention has been cancelled";
        }
        protected void GotoList(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Manager/ListInterventions.aspx");
        }
    }
 }
    
