using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public class Verify
    {
        public String Username
        {
            get
            {
                return "";
            }
        }

        public String Password
        {
            get
            {
                return "";
            }
        }

        public bool Login(string Uname, string Pword)
        {
            return true;
        }

        public string OutReport(string input)
        {
            string output = "";
            return output;
        }

        public string AddClient(string info)
        {
            string intervention1 = "info";
            return intervention1;
        }


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