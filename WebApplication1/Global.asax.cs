﻿using Microsoft.AspNet.Identity;
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

            var findAdmin = userManager.FindByEmail("admin@admin.com");
            var findManager = userManager.FindByEmail("manager@manager.com");
            var findAccountant = userManager.FindByEmail("accountant@accountant.com");
            var findSiteEnginner = userManager.FindByEmail("siteengineer@siteengineer.com");
            //var finduser = userManager.FindByEmail("yams.stj@gmail.com");

            if (Utils.getInstance.isNullOrEmpty(findAdmin) && Utils.getInstance.isNullOrEmpty(findManager)
                && Utils.getInstance.isNullOrEmpty(findAccountant) && Utils.getInstance.isNullOrEmpty(findSiteEnginner))
                //&& Utils.getInstance.isNullOrEmpty(finduser))
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
                var siteEnginner = new IdentityUser() { UserName = "Site Engineer", Email = "siteengineer@siteengineer.com" };
                IdentityResult resultSiteEngineer = await userManager.CreateAsync(siteEnginner, "123456");
                if (resultSiteEngineer.Succeeded)
                {
                    userManager.AddToRole(siteEnginner.Id, Roles.SiteEngineer.ToString());
                }
                //var user = new IdentityUser() { UserName = "yams.stj", Email = "yams.stj@gmail.com" };
                //IdentityResult result = await userManager.CreateAsync(user, "123456");
                //if (result.Succeeded)
                //{
                //    userManager.AddToRole(user.Id, Roles.Admin.ToString());
                //}
            }
        }
    }
}