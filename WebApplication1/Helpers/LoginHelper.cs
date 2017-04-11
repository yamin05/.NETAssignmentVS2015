using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class LoginHelper
    {
        public User loginHelperLogin(String inputEmail, String inputPassword)
        {
            User user = new User();
            if (user.LoginSuccessful(inputEmail, inputPassword))
            {
                return user;
            } else
            {
                return null;
            }
        }
    }
}