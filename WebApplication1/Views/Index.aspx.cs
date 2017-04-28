using System;
using System.Web.UI;

namespace WebApplication1
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User != null && Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect(Utils.getInstance.getHomePageURL());
            }
        }
    }
}