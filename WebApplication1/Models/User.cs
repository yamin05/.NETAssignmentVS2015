using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Exceptions;

namespace WebApplication1.Models
{
    public class User
    {
        private string username = "yams.stj@gmail.com";
        private string password = "1234";
        private string role = "manager";

        public string Username
        {
            get
            {
                return username;
            }

            private set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            private set
            {
                password = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            private set
            {
                role = value;
            }
        }

        public bool LoginSuccessful(string inputEmail, string inputPassword)
        {
            //Database code will be here....for now it is hard coded
            if (!String.Equals(inputEmail, Username))
            {
                throw new WrongInputEmailException();
            }
            if (!String.Equals(inputPassword, Password))
            {
                throw new WrongInputPasswordException();
            }
            return true;
        }
    }
}