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

            var findUser = userManager.FindByEmail("admin@admin.com");
            var findUser2 = userManager.FindByEmail("yams.stj@gmail.com");

            if (Utils.getInstance.isNullOrEmpty(findUser) && Utils.getInstance.isNullOrEmpty(findUser2))
            {
                var user = new IdentityUser() { UserName = "admin", Email = "admin@admin.com"};
                IdentityResult result = await userManager.CreateAsync(user, "adminadmin");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, Roles.Admin.ToString());
                }
                var user2 = new IdentityUser() { UserName = "yams.stj", Email = "yams.stj@gmail.com" };
                IdentityResult result2 = await userManager.CreateAsync(user2, "123456");
                if (result2.Succeeded)
                {
                    userManager.AddToRole(user2.Id, Roles.Manager.ToString());
                }
            }
        }
    }
}