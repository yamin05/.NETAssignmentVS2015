using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public class Verify
    {
        public static bool VerifyUsername(string username)
        {
            if (username != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyName(string firstname, string lastname)
        {
            if (firstname != "" && lastname != ""
                && Regex.IsMatch(firstname, "^[ A-Za-z]*$")
                && Regex.IsMatch(lastname, "^[ A-Za-z]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool VerifyEngineerLimit(decimal interventionhour, decimal interventioncost)
        {
            if (interventionhour > 50 || interventioncost > 2000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}