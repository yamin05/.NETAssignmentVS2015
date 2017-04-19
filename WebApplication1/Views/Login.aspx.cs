using System;
using System.Web.UI;
using WebApplication1.Helpers;

namespace WebApplication1.Account
{
    public partial class ViewLogin : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    LoginHelper loginHelper = new LoginHelper();
                    var homePage = loginHelper.login(Username.Text, Password.Text);
                    Response.Redirect(homePage);
                }
                catch (Exception ex)
                {
                    FailureText.Text = ex.Message;
                    ErrorMessage.Visible = true;
                }
            }
            else
            {
                ErrorMessage.Visible = false;
            }
        }
    }
}