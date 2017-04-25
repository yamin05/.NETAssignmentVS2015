using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Exceptions;

namespace WebApplication1.Models
{
    public class User
    {
        
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public string Email { get; set; }


        //public bool LoginSuccessful(string inputEmail, string inputPassword)
        //{
        //    //Database code will be here....for now it is hard coded
        //    if (!String.Equals(inputEmail, Username))
        //    {
        //        throw new WrongInputEmailException();
        //    }
        //    if (!String.Equals(inputPassword, Password))
        //    {
        //        throw new WrongInputPasswordException();
        //    }
        //    return true;
        //}
    }
}