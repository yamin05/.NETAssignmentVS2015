using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User != null && Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect(Utils.getInstance.getHomePageURL(User.Identity.Name));
            }
        }
    }
}