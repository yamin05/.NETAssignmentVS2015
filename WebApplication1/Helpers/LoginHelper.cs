using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Web;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class LoginHelper
    {
        public string login(String inputEmail, String inputPassword)
        {
            //User user = new User();

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var findUser = userManager.Find(inputEmail, inputPassword);

            if (findUser != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(findUser, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                if (userManager.IsInRole(findUser.Id, Roles.Admin.ToString()))
                {
                    return Roles.Admin.ToString();
                }
            }
            else
            {
                throw new WrongUserInputException();
            }
            return null;

            //if (user.LoginSuccessful(inputEmail, inputPassword))
            //{
            //    return user;
            //}
            //else
            //{
            //    return null;
            //}
        }
    }
}