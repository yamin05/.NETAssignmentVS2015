using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Web;
using WebApplication1.Exceptions;

namespace WebApplication1.Helpers
{
    public class LoginHelper
    {
        public string login(String inputUsername, String inputPassword)
        {
            //User user = new User();

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var findUser = userManager.Find(inputUsername, inputPassword);

            if (findUser != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(findUser, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                var roles = userManager.GetRoles(findUser.Id);
                
                return Utils.getInstance.getHomePageURL(roles[0]);
            }
            
            else
            {
                throw new WrongUserInputException();
            }
            //return null;

            //if (user.LoginSuccessful(inputUsername, inputPassword))
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