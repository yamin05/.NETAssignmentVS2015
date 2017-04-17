using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebApplication1.Models;
using WebApplication1.Utils;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CreateOrCheckAdminUser();
        }

        private async void CreateOrCheckAdminUser()
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var findUser = userManager.FindByEmail("admin@admin.com");
            if (ValidationUtil.Instance.isNullOrEmpty(findUser))
            {
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole();
                    role.Name = Roles.Admin.ToString();
                    roleManager.Create(role);
                }
                if (!roleManager.RoleExists("Manager"))
                {
                    var role = new IdentityRole();
                    role.Name = Roles.Manager.ToString();
                    roleManager.Create(role);
                }  
                if (!roleManager.RoleExists("SiteEngineer"))
                {
                    var role = new IdentityRole();
                    role.Name = Roles.SiteEngineer.ToString();
                    roleManager.Create(role);
                }
                if (!roleManager.RoleExists("Accountant"))
                {
                    var role = new IdentityRole();
                    role.Name = Roles.Accountant.ToString();
                    roleManager.Create(role);
                }
                var user = new IdentityUser() { UserName = "admin@admin.com", Email = "admin@admin.com"};
                IdentityResult result = await userManager.CreateAsync(user, "adminadmin");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, Roles.Admin.ToString());
                }
            }
        }
    }
}