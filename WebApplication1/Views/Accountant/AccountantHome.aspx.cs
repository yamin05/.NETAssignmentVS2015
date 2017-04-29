using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Views.Accountant
{
    public partial class AccountantHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ChangePassword.aspx");
        }
        protected void UsersList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Accountant/UsersList.aspx");
        }

        protected void ChangeDistrict_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Accountant/ChangeDistrict.aspx");
        }

        protected void TotalCostByEngineer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Accountant/TotalCostByEngineer.aspx");
        }

        protected void AverageCostByEngineer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Accountant/AverageCostByEngineer.aspx");
        }

        protected void CostByDistrict_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Accountant/CostByDistrict.aspx");
        }

        protected void MonthlyCostForDistrict_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Accountant/MonthlyCostForDistrict.aspx");
        }
    }
}