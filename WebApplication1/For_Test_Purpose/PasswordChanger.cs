using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class PasswordChanger
    {

        public String password
        {
            get; set;
        }


        public String oldPassword
        {
            get; set;
        }

        public string newPassword
        {
            get; set;
        }
        public string confirmPassword
        {
            get; set;
        }

        public Int32 flag = 0;
        public Int32 ConfirmPass(string newPassword, string confirmPassword)
        {
            if (confirmPassword == newPassword)
            {
                return flag = 1;
                
            }
            else
            {
                return flag = 0;
            }
        }
        public void ChangePassword(string newPassword, string oldPassword, string password, string comfirmPassword)
        {
            if (oldPassword == null || oldPassword.Trim() == string.Empty)
            {
                Console.WriteLine("Old Password is Empty");
            }
            else
            if (password == oldPassword && flag==1)
            {
                password = newPassword;
            }
            else
            {
                throw new ArgumentException(
                   "The old password was not correct.");
            }
        }
    }
 }
    
