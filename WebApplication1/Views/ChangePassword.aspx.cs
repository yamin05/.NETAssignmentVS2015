using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApplication1.Helpers;

namespace WebApplication1
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

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
                    // Strip the query string from action
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



    //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
    //IdentityResult result = manager.ChangePassword(User.Identity.GetUserId(), CurrentPassword.Text, NewPassword.Text);
    //if (result.Succeeded)
    ////{
    //    var user = manager.FindById(User.Identity.GetUserId());
    //    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
    //    if (manager.IsInRole(User.Identity.GetUserId(), Roles.SiteEngineer.ToString()))
    //    {
    //        Response.Write("<script language='javascript'>window.alert('Password has been Changed');window.location='SiteEngineer/EngineerHome.aspx?m=ChangePwdSucce';</script>");

    //    }
    //    else
    //        if (manager.IsInRole(User.Identity.GetUserId(), Roles.Manager.ToString()))
    //    {
    //        Response.Write("<script language='javascript'>window.alert('Password has been Changed');window.location='Manager/ManagerHome.aspx?m=ChangePwdSucces';</script>");

    //    }
    //    else
    //        if (manager.IsInRole(User.Identity.GetUserId(), Roles.Accountant.ToString()))
    //    {
    //        Response.Write("<script language='javascript'>window.alert('Password has been Changed');window.location='Accountant/AccountantHome.aspx?m=ChangePwdSucces';</script>");

    //    }
    //}
    //else
    //{
    //    AddErrors(result);
    //}
//}
//        }

        //protected void SetPassword_Click(object sender, EventArgs e)
        //{
        //    if (IsValid)
        //    {
        //        // Create the local login info and link the local account to the user
        //        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //        IdentityResult result = manager.AddPassword(User.Identity.GetUserId(), password.Text);
        //        if (result.Succeeded && result.ToString().Equals(Roles.Manager.ToString()))
        //        {
        //            Response.Redirect("~/Views/Manager/ManagerHome.aspx");
        //        }
        //        else
        //        {
        //            AddErrors(result);
        //        }
        //    }
        //}

    //    private void AddErrors(IdentityResult result)
    //    {
    //        foreach (var error in result.Errors)
    //        {
    //            ModelState.AddModelError("", error);
    //        }
    //    }
    //}
}