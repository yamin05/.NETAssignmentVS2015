using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication1.Models;
using WebApplication1.Utils;
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
                    var roles = loginHelper.login(Email.Text, Password.Text);
                    if (roles.ToString().Equals(Roles.Admin.ToString()))
                    {
                        Response.Redirect("~/Views/Manager/ManagerHome.aspx");
                    }
                    else
                    {
                        FailureText.Text = "Only Managers can login for now. No other pages created";
                        ErrorMessage.Visible = true;
                    }
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