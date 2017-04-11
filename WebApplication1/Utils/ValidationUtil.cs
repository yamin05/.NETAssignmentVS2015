using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using WebApplication1.Exceptions;

namespace WebApplication1.Utils
{
    public sealed class ValidationUtil
    {
        private static readonly ValidationUtil instance = new ValidationUtil();

        private ValidationUtil() { }

        public static ValidationUtil Instance
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
    }
}