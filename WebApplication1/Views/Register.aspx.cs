using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Account
{
    public partial class ViewRegister : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, Roles.SiteEngineer.ToString());
                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos = new UserRepository(context);
                var user2 = new Users();
                user2.UserId = user.Id;
                user2.MaximumHours = 1000;
                user2.MaximumCost = 1000;
                user2.District = (int)Districts.Sydney;
                repos.Insert(user2);
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}