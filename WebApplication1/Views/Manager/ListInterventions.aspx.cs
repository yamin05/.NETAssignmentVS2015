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
            if (!IsPostBack)

            {
                GridView1.DataSource = CreateSource();
                GridView1.DataBind();
            }
        }

       public DataSet CreateSource()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            List<Interventions> ProposedInterList = new List<Interventions>();
            ProposedInterList = listInterventions.ListOfProposedInterventions(userId).ToList();
            DataSet ds = ListToDatasetExtension.ToDataSet<Interventions>(ProposedInterList);
            return ds;
        }
     }     
 }
    
