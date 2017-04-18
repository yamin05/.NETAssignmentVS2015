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
                    if (roles.ToString().Equals(Roles.SiteEngineer.ToString()))
                    {
                        Response.Redirect("~/Views/SiteEngineer/EngineerHome.aspx");
                    }
                    else
                     if (roles.ToString().Equals(Roles.Manager.ToString()))

                    {
                        Response.Redirect("~/Views/Manager/ManagerHome.aspx");
                    }
                    else

                    if (roles.ToString().Equals(Roles.Admin.ToString()))

                    {
                        Response.Redirect("~/Views/Manager/ManagerHome.aspx");
                    }
                    else

                    if (roles.ToString().Equals(Roles.Accountant.ToString()))

                    {
                        Response.Redirect("~/Views/Accountant/AccountantHome.aspx");
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