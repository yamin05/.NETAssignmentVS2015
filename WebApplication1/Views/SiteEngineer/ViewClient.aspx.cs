﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Views.SiteEngineer
{
    public partial class ViewClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/SiteEngineer/CreateClient.aspx");
        }
        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {

        }
    }
}