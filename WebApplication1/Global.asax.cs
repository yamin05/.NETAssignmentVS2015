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

            var findAdmin = userManager.FindByEmail("admin@enet.com");
            var findAccountant = userManager.FindByEmail("accountant@enet.com");
            var findManager = userManager.FindByEmail("manager1@enet.com");
            var findSiteEngineer = userManager.FindByEmail("siteengineer1@enet.com");
            var findSiteEngineer2 = userManager.FindByEmail("siteengineer2sydeny@enet.com");
            var findManager2 = userManager.FindByEmail("manager2@enet.com");
            var findSiteEngineer3 = userManager.FindByEmail("siteengineer3@enet.com");
            var findSiteEngineer4 = userManager.FindByEmail("siteengineer4@enet.com");
            var findManager3 = userManager.FindByEmail("manager3@enet.com");
            var findSiteEngineer5 = userManager.FindByEmail("siteengineer5@enet.com");
            var findSiteEngineer6 = userManager.FindByEmail("siteengineer6@enet.com");
            var findManager4 = userManager.FindByEmail("manager4@enet.com");
            var findSiteEngineer7 = userManager.FindByEmail("siteengineers7@enet.com");
            var findSiteEngineer8 = userManager.FindByEmail("siteengineer8@enet.com");
            var findManager5 = userManager.FindByEmail("manager5@enet.com");
            var findSiteEngineer9 = userManager.FindByEmail("siteengineer9@enet.com");
            var findSiteEngineer10 = userManager.FindByEmail("siteengineer10@enet.com");
            var findManager6 = userManager.FindByEmail("manager6@enet.com");
            var findSiteEngineer11 = userManager.FindByEmail("siteengineer11@enet.com");
            var findSiteEngineer12 = userManager.FindByEmail("siteengineer12@enet.com");

            if (Utils.getInstance.isNullOrEmpty(findAdmin) && Utils.getInstance.isNullOrEmpty(findManager)
                && Utils.getInstance.isNullOrEmpty(findAccountant) && Utils.getInstance.isNullOrEmpty(findSiteEngineer)
                && Utils.getInstance.isNullOrEmpty(findSiteEngineer2)&&Utils.getInstance.isNullOrEmpty(findManager2)
                && Utils.getInstance.isNullOrEmpty(findSiteEngineer3)  && Utils.getInstance.isNullOrEmpty(findSiteEngineer4)
                && Utils.getInstance.isNullOrEmpty(findManager3)  && Utils.getInstance.isNullOrEmpty(findSiteEngineer5)
                && Utils.getInstance.isNullOrEmpty(findSiteEngineer6) && Utils.getInstance.isNullOrEmpty(findManager4)  
                && Utils.getInstance.isNullOrEmpty(findSiteEngineer7) && Utils.getInstance.isNullOrEmpty(findSiteEngineer8) 
                && Utils.getInstance.isNullOrEmpty(findManager5)  && Utils.getInstance.isNullOrEmpty(findSiteEngineer9)
                && Utils.getInstance.isNullOrEmpty(findSiteEngineer10)   && Utils.getInstance.isNullOrEmpty(findManager6)
                && Utils.getInstance.isNullOrEmpty(findSiteEngineer11)&& Utils.getInstance.isNullOrEmpty(findSiteEngineer12)
                )
            {
                var admin = new IdentityUser() { UserName = "Admin", Email = "admin@enet.com"};
                IdentityResult resultAdmin = await userManager.CreateAsync(admin, "123456");
                if (resultAdmin.Succeeded)
                {
                    userManager.AddToRole(admin.Id, Roles.Admin.ToString());
                }
                var manager1 = new IdentityUser() { UserName = "Manager1", Email = "manager1@enet.com" };
                IdentityResult resultManager1 = await userManager.CreateAsync(manager1, "123456");
                if (resultManager1.Succeeded)
                {
                    userManager.AddToRole(manager1.Id, Roles.Manager.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos = new UserRepository(context);
                    var user = new Users();
                    user.UserId = manager1.Id;
                    user.MaximumHours = 100;
                    user.MaximumCost = 5000;
                    user.District = (int)Districts.Urban_Indonesia;
                    repos.Insert(user);
                }
                var manager2 = new IdentityUser() { UserName = "Manager2", Email = "manager2@enet.com" };
                IdentityResult resultManager2 = await userManager.CreateAsync(manager2, "123456");
                if (resultManager2.Succeeded)
                {
                    userManager.AddToRole(manager2.Id, Roles.Manager.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos = new UserRepository(context);
                    var user = new Users();
                    user.UserId = manager2.Id;
                    user.MaximumHours = 100;
                    user.MaximumCost = 5000;
                    user.District = (int)Districts.Rural_Indonesia;
                    repos.Insert(user);
                }
                var manager3 = new IdentityUser() { UserName = "Manager3", Email = "manager3@enet.com" };
                IdentityResult resultManager3 = await userManager.CreateAsync(manager3, "123456");
                if (resultManager3.Succeeded)
                {
                    userManager.AddToRole(manager3.Id, Roles.Manager.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos = new UserRepository(context);
                    var user = new Users();
                    user.UserId = manager3.Id;
                    user.MaximumHours = 100;
                    user.MaximumCost = 5000;
                    user.District = (int)Districts.Urban_Papua_New_Guinea;
                    repos.Insert(user);
                }
                var manager4 = new IdentityUser() { UserName = "Manager4", Email = "manager4@enet.com" };
                IdentityResult resultManager4 = await userManager.CreateAsync(manager4, "123456");
                if (resultManager4.Succeeded)
                {
                    userManager.AddToRole(manager4.Id, Roles.Manager.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos = new UserRepository(context);
                    var user = new Users();
                    user.UserId = manager4.Id;
                    user.MaximumHours = 100;
                    user.MaximumCost = 5000;
                    user.District = (int)Districts.Rural_Papua_New_Guinea;
                    repos.Insert(user);
                }
                var manager5 = new IdentityUser() { UserName = "Manager5", Email = "manager5@enet.com" };
                IdentityResult resultManager5 = await userManager.CreateAsync(manager5, "123456");
                if (resultManager5.Succeeded)
                {
                    userManager.AddToRole(manager5.Id, Roles.Manager.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos = new UserRepository(context);
                    var user = new Users();
                    user.UserId = manager5.Id;
                    user.MaximumHours = 100;
                    user.MaximumCost = 5000;
                    user.District = (int)Districts.Sydney;
                    repos.Insert(user);
                }
                var manager6 = new IdentityUser() { UserName = "Manager6", Email = "manager6@enet.com" };
                IdentityResult resultManager6 = await userManager.CreateAsync(manager6, "123456");
                if (resultManager6.Succeeded)
                {
                    userManager.AddToRole(manager6.Id, Roles.Manager.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos = new UserRepository(context);
                    var user = new Users();
                    user.UserId = manager6.Id;
                    user.MaximumHours = 100;
                    user.MaximumCost = 5000;
                    user.District = (int)Districts.Rural_New_South_Wales;
                    repos.Insert(user);
                }
                var accountant = new IdentityUser() { UserName = "Accountant", Email = "accountant@enet.com" };
                IdentityResult resultAccountant = await userManager.CreateAsync(accountant, "123456");
                if (resultAccountant.Succeeded)
                {
                    userManager.AddToRole(accountant.Id, Roles.Accountant.ToString());
                }
                var siteEngineer1 = new IdentityUser() { UserName = "siteengineer1", Email = "siteengineer1@enet.com" };
                IdentityResult resultSiteEngineer1 = await userManager.CreateAsync(siteEngineer1, "123456");
                if (resultSiteEngineer1.Succeeded)
                {
                    userManager.AddToRole(siteEngineer1.Id, Roles.SiteEngineer.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos = new UserRepository(context);
                    var user = new Users();
                    user.UserId = siteEngineer1.Id;
                    user.MaximumHours = 50;
                    user.MaximumCost = 2000;
                    user.District = (int) Districts.Urban_Indonesia;
                    repos.Insert(user);
                }
                var siteEngineer2 = new IdentityUser() { UserName = "siteengineer2", Email = "siteengineer2@enet.com" };
                IdentityResult resultSiteEngineer2 = await userManager.CreateAsync(siteEngineer2, "123456");
                if (resultSiteEngineer2.Succeeded)
                {
                    userManager.AddToRole(siteEngineer2.Id, Roles.SiteEngineer.ToString());

                    var factory = new DbConnectionFactory("CustomDatabase");
                    var context = new DbContext(factory);
                    var repos2 = new UserRepository(context);
                    var user2 = new Users();
                    user2.UserId = siteEngineer2.Id;
                    user2.MaximumHours = 25;
                    user2.MaximumCost = 1000;
                    user2.District = (int)Districts.Urban_Indonesia;
                    repos2.Insert(user2);
                }
            }
            var siteEngineer3 = new IdentityUser() { UserName = "siteengineer3", Email = "siteengineer3@enet.com" };
            IdentityResult resultsiteEngineer3 = await userManager.CreateAsync(siteEngineer3, "123456");
            if (resultsiteEngineer3.Succeeded)
            {
                userManager.AddToRole(siteEngineer3.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos = new UserRepository(context);
                var user = new Users();
                user.UserId = siteEngineer3.Id;
                user.MaximumHours = 50;
                user.MaximumCost = 2000;
                user.District = (int)Districts.Rural_Indonesia;
                repos.Insert(user);
            }
            var siteEngineer4 = new IdentityUser() { UserName = "siteengineer4", Email = "siteengineer4@enet.com" };
            IdentityResult resultsiteEngineer4 = await userManager.CreateAsync(siteEngineer4, "123456");
            if (resultsiteEngineer4.Succeeded)
            {
                userManager.AddToRole(siteEngineer4.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos2 = new UserRepository(context);
                var user2 = new Users();
                user2.UserId = siteEngineer4.Id;
                user2.MaximumHours = 25;
                user2.MaximumCost = 1000;
                user2.District = (int)Districts.Rural_Indonesia;
                repos2.Insert(user2);
            }   
            var siteEngineer5 = new IdentityUser() { UserName = "Siteengineer5", Email = "siteengineer5@enet.com" };
            IdentityResult resultsiteEngineer5 = await userManager.CreateAsync(siteEngineer5, "123456");
            if (resultsiteEngineer5.Succeeded)
            {
                userManager.AddToRole(siteEngineer5.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos = new UserRepository(context);
                var user = new Users();
                user.UserId = siteEngineer5.Id;
                user.MaximumHours = 50;
                user.MaximumCost = 2000;
                user.District = (int)Districts.Urban_Papua_New_Guinea;
                repos.Insert(user);
            }
            var siteEngineer6 = new IdentityUser() { UserName = "Siteengineer6", Email = "siteengineer6@enet.com" };
            IdentityResult resultsiteEngineer6 = await userManager.CreateAsync(siteEngineer6, "123456");
            if (resultsiteEngineer6.Succeeded)
            {
                userManager.AddToRole(siteEngineer6.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos2 = new UserRepository(context);
                var user2 = new Users();
                user2.UserId = siteEngineer6.Id;
                user2.MaximumHours = 25;
                user2.MaximumCost = 1000;
                user2.District = (int)Districts.Urban_Papua_New_Guinea;
                repos2.Insert(user2);
            }
            var siteEngineer7 = new IdentityUser() { UserName = "siteengineer7", Email = "siteengineer7@enet.com" };
            IdentityResult resultsiteEngineer7 = await userManager.CreateAsync(siteEngineer7, "123456");
            if (resultsiteEngineer7.Succeeded)
            {
                userManager.AddToRole(siteEngineer7.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos = new UserRepository(context);
                var user = new Users();
                user.UserId = siteEngineer7.Id;
                user.MaximumHours = 50;
                user.MaximumCost = 2000;
                user.District = (int)Districts.Rural_Papua_New_Guinea;
                repos.Insert(user);
            }
            var siteEngineer8 = new IdentityUser() { UserName = "siteengineer8", Email = "siteengineer8@siteengineer.com" };
            IdentityResult resultsiteEngineer8 = await userManager.CreateAsync(siteEngineer8, "123456");
            if (resultsiteEngineer8.Succeeded)
            {
                userManager.AddToRole(siteEngineer8.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos2 = new UserRepository(context);
                var user2 = new Users();
                user2.UserId = siteEngineer8.Id;
                user2.MaximumHours = 25;
                user2.MaximumCost = 1000;
                user2.District = (int)Districts.Rural_Papua_New_Guinea;
                repos2.Insert(user2);
            }
            var siteEngineer9 = new IdentityUser() { UserName = "siteengineer9", Email = "siteengineer9@enet.com" };
            IdentityResult resultsiteEngineer9 = await userManager.CreateAsync(siteEngineer9, "123456");
            if (resultsiteEngineer9.Succeeded)
            {
                userManager.AddToRole(siteEngineer9.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos = new UserRepository(context);
                var user = new Users();
                user.UserId = siteEngineer9.Id;
                user.MaximumHours = 50;
                user.MaximumCost = 2000;
                user.District = (int)Districts.Sydney;
                repos.Insert(user);
            }
            var siteEngineer10 = new IdentityUser() { UserName = "siteEngineer10", Email="siteengineer10@enet.com" };
            IdentityResult resultsiteEngineer10 = await userManager.CreateAsync(siteEngineer10, "123456");
            if (resultsiteEngineer10.Succeeded)
            {
                userManager.AddToRole(siteEngineer10.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos2 = new UserRepository(context);
                var user2 = new Users();
                user2.UserId = siteEngineer10.Id;
                user2.MaximumHours = 25;
                user2.MaximumCost = 1000;
                user2.District = (int)Districts.Sydney;
                repos2.Insert(user2);
            }
            var siteEngineer11 = new IdentityUser() { UserName = "siteengineer11", Email = "siteengineer11@enet.com" };
            IdentityResult resultsiteEngineer11 = await userManager.CreateAsync(siteEngineer11, "123456");
            if (resultsiteEngineer11.Succeeded)
            {
                userManager.AddToRole(siteEngineer11.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos = new UserRepository(context);
                var user = new Users();
                user.UserId = siteEngineer11.Id;
                user.MaximumHours = 50;
                user.MaximumCost = 2000;
                user.District = (int)Districts.Rural_New_South_Wales;
                repos.Insert(user);
            }
            var siteEngineer12 = new IdentityUser() { UserName = "siteengineer12", Email="siteengineer12@enet.com" };
            IdentityResult resultsiteEngineer12 = await userManager.CreateAsync(siteEngineer12, "123456");
            if (resultsiteEngineer12.Succeeded)
            {
                userManager.AddToRole(siteEngineer12.Id, Roles.SiteEngineer.ToString());

                var factory = new DbConnectionFactory("CustomDatabase");
                var context = new DbContext(factory);
                var repos2 = new UserRepository(context);
                var user2 = new Users();
                user2.UserId = siteEngineer12.Id;
                user2.MaximumHours = 25;
                user2.MaximumCost = 1000;
                user2.District = (int)Districts.Rural_New_South_Wales;
                repos2.Insert(user2);
            }
        }
    }
}