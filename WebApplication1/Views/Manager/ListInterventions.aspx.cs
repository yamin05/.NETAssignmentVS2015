using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Helpers;
using Microsoft.AspNet.Identity;
using System.Data;
using WebApplication1.Models;
using WebApplication1.Extensions;

namespace WebApplication1.Views.Manager
{
    public partial class ListInterventions : System.Web.UI.Page
    {
        private ListInterventionsHelper listInterventions = new ListInterventionsHelper("DefaultConnection");
        protected void Page_Load(object sender, EventArgs e)
        {

            GridView1.DataSource = CreateSource();
            GridView1.DataBind();

        }

        public DataTable CreateSource()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            List<Interventions> ProposedInterList = new List<Interventions>();
            ProposedInterList = listInterventions.ListOfProposedInterventions(userId).ToList();
            //DataSet ds = ListToDatasetExtension.ToDataSet<Interventions>(ProposedInterList);

            
            DataTable datatable = new DataTable();
            datatable.Columns.Add(new DataColumn("InterventionId", typeof(int)));
            datatable.Columns.Add(new DataColumn("ClientId", typeof(int)));
            datatable.Columns.Add(new DataColumn("InterventionCost", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("InterventionHour", typeof(decimal)));
            datatable.Columns.Add(new DataColumn("CreateDate", typeof(DateTime)));
            datatable.Columns.Add(new DataColumn("Status", typeof(string)));
            foreach (var row in ProposedInterList)
            {
                datatable.Rows.Add(CreateRow(row.InterventionId,  row.ClientId,  row.InterventionCost, row.InterventionHour, row.CreateDate, Enum.GetName(typeof(Status), row.Status), datatable));


            }
            
            return datatable;
            
        }

        DataRow CreateRow(int InterventionId,int ClientId,decimal InterventionCost, decimal InterventionHour,DateTime CreateDate, string status , DataTable datatable)
        {
            DataRow datarow = datatable.NewRow();
            datarow[0] = InterventionId;
            datarow[1] = ClientId;
            datarow[2] = InterventionCost;
            datarow[3] = InterventionHour;
            datarow[4] = CreateDate;
            datarow[5] = status;
            return datarow;
        }
    }
}
       
 
    
