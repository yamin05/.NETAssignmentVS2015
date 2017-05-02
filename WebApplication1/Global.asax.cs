using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication1.Models;
using WebApplication1.Repositories;

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
            CreateInterventionType();
        }

        private void CreateInterventionType()
        {
            var factory = new DbConnectionFactory("CustomDatabase");
            var context = new DbContext(factory);
            var repos = new InterventionTypeRepository(context);
            var interventionType = new InterventionType();
            var rows = repos.GetAll();
            if (rows.Count == 0)
            {
                interventionType.InterventionTypeName = "Supply and Install Portable Toilet";
                interventionType.InterventionTypeHours = 10;
                interventionType.InterventionTypeCost = 200;
                repos.Insert(interventionType);
                interventionType.InterventionTypeName = "Hepatitis Avoidance Training";
                interventionType.InterventionTypeHours = 15;
                interventionType.InterventionTypeCost = 300;
                repos.Insert(interventionType);
                interventionType.InterventionTypeName = "Supply and Install Storm-proof Home Kit";
                interventionType.InterventionTypeHours = 50;
                interventionType.InterventionTypeCost = 500;
                repos.Insert(interventionType);
            }
            
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

            var findAdmin = userManager.FindByEmail("admin@admin.com");
            var findManager = userManager.FindByEmail("manager@manager.com");
            var findAccountant = userManager.FindByEmail("accountant@accountant.com");
            var findSiteEngineer = userManager.FindByEmail("siteengineer@siteengineer.com");
            var findSiteEngineer2 = userManager.FindByEmail("siteengineer2@siteengineer.com");

            if (Utils.getInstance.isNullOrEmpty(findAdmin) && Utils.getInstance.isNullOrEmpty(findManager)
                && Utils.getInstance.isNullOrEmpty(findAccountant) && Utils.getInstance.isNullOrEmpty(findSiteEngineer)
                && Utils.getInstance.isNullOrEmpty(findSiteEngineer2))
            {
                var admin = new IdentityUser() { UserName = "Admin", Email = "admin@admin.com"};
                IdentityResult resultAdmin = await userManager.CreateAsync(admin, "123456");
                if (resultAdmin.Succeeded)
                {
                    userManager.AddToRole(admin.Id, Roles.Admin.ToString());
                }
                var manager = new IdentityUser() { UserName = "Manager", Email = "manager@manager.com" };
                IdentityResult resultManager = await userManager.CreateAsync(manager, "123456");
                if (resultManager.Succeeded)
                {
                    userManager.AddToRole(manager.Id, Roles.Manager.ToString());
                }
                var accountant = new IdentityUser() { UserName = "Accountant", Email = "accountant@accountant.com" };
                IdentityResult resultAccountant = await userManager.CreateAsync(accountant, "123456");
                if (resultAccountant.Succeeded)
                {
                    userManager.AddToRole(accountant.Id, Roles.Accountant.ToString());
                }
                var siteEngineer = new IdentityUser() { UserName = "SiteEngineer", Email = "siteengineer@siteengineer.com" };
                IdentityResult resultSiteEngineer = await userManager.CreateAsync(siteEngineer, "123456");
                if (resultSiteEngineer.Succeeded)
                {
                    userManager.AddToRole(siteEngineer.Id, Roles.SiteEngineer.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos = new UserRepository(context);
                    var user = new Users();
                    user.UserId = siteEngineer.Id;
                    user.MaximumHours = 50;
                    user.MaximumCost = 2000;
                    user.District = (int) Districts.Sydney;
                    repos.Insert(user);
                }
                var siteEngineer2 = new IdentityUser() { UserName = "SiteEngineer2", Email = "siteengineer2@siteengineer.com" };
                IdentityResult resultSiteEngineer2 = await userManager.CreateAsync(siteEngineer2, "123456");
                if (resultSiteEngineer2.Succeeded)
                {
                    userManager.AddToRole(siteEngineer2.Id, Roles.SiteEngineer.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos2 = new UserRepository(context);
                    var user2 = new Users();
                    user2.UserId = siteEngineer2.Id;
                    user2.MaximumHours = 50;
                    user2.MaximumCost = 2000;
                    user2.District = (int)Districts.Rural_New_South_Wales;
                    repos2.Insert(user2);
                }
            }
        }
    }
}