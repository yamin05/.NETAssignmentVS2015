using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Text.RegularExpressions;
using WebApplication1.Exceptions;

namespace WebApplication1
{
    public sealed class Utils
    {
        private static readonly Utils instance = new Utils();

        private Utils() { }

        public static Utils getInstance
        {
            get
            {
                return instance;
            }
        }
        public void validateEmail(string inputEmail)
        {
            if (isNullOrEmpty(inputEmail))
            {
                throw new ValueIsNullException();
            }
            Regex regex = new Regex(@"\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            Match match = regex.Match(inputEmail);
            if (!match.Success)
            {
                throw new InvalidEmailFormatException();
            }
        }

        public void validatePassword(string inputPassword)
        {
            if (isNullOrEmpty(inputPassword))
            {
                throw new ValueIsNullException();
            }
            Regex regex = new Regex(@"\w{4,8}");
            Match match = regex.Match(inputPassword);
            if (!match.Success)
            {
                throw new InvalidEmailFormatException();
            }
        }

        public bool isNullOrEmpty(object obj)
        {
            return obj == null || obj.Equals("");
        }

        public string getHomePageURL(Roles role)
        {
            return role.ToString() +  "/" + role.ToString() + "Home.aspx";
        }

        public string getHomePageURL(string username)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var findUser = userManager.FindByName(username);
            var roles = userManager.GetRoles(findUser.Id);

            return "~/Views/" + roles[0] + "/" + roles[0] + "Home.aspx";
        }
    }
}