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
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
        }

        

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                
                try
                {
                    LoginHelper loginHelper = new LoginHelper();
                    User loggedInUser = loginHelper.loginHelperLogin(Email.Text, Password.Text);
                    if (!ValidationUtil.Instance.isNullOrEmpty(loggedInUser))
                    {
                        ((SiteMainMaster)this.Master).username = loggedInUser.Username;
                        if (loggedInUser.Role.Equals("manager"))
                        {
                            Server.Transfer("Manager/ManagerHome.aspx");
                        } else
                        {
                            FailureText.Text = "Only Managers can login for now. No other pages created";
                            ErrorMessage.Visible = true;
                        }
                    }
                } catch (Exception ex)
                {
                    FailureText.Text = ex.Message;
                    ErrorMessage.Visible = true;
                }
                
                //// Validate the user password
                //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                //// This doen't count login failures towards account lockout
                //// To enable password failures to trigger lockout, change to shouldLockout: true
                //var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                //switch (result)
                //{
                //    case SignInStatus.Success:
                //        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //        break;
                //    case SignInStatus.LockedOut:
                //        Response.Redirect("/Account/Lockout");
                //        break;
                //    case SignInStatus.RequiresVerification:
                //        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                //                                        Request.QueryString["ReturnUrl"],
                //                                        RememberMe.Checked),
                //                          true);
                //        break;
                //    case SignInStatus.Failure:
                //    default:
                //        FailureText.Text = "Invalid login attempt";
                //        ErrorMessage.Visible = true;
                //        break;
                //}
            }
            else
            {
                ErrorMessage.Visible = false;
            }
        }
    }
}