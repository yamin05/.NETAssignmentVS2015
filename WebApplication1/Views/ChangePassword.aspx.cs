using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApplication1.Helpers;
using System.Web.UI;

namespace WebApplication1
{
    public partial class ChangePassword : Page
    {
        protected string SuccessMessage { get; private set; }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    changePasswordHolder.Visible = true;
                }
                else
                {
                    changePasswordHolder.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    Form.Action = ResolveUrl("~/Views/ChangePassword");
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    ChangePasswordHelper ChangePasswordFunc = new ChangePasswordHelper();
                    string user = User.Identity.GetUserId();
                    var homePage = ChangePasswordFunc.ChangePasswordFun(user,CurrentPassword.Text,NewPassword.Text);
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