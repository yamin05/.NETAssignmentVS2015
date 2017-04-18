using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Views

{
    public partial class ChangePassword : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button2_click(object sender, EventArgs e)
        {
            User user = new User();
            string oldPassword;
            string newPassword;
            string confirmPassword;
            oldPassword = TextBox1.Text;
            newPassword = TextBox2.Text;
            confirmPassword = TextBox3.Text;
            string userPassword;
            userPassword = user.Password;



            if (oldPassword == userPassword && newPassword == confirmPassword)
            {
                Response.Write("<script>alert('Your password has been changed');window.location.href='Login.aspx'</script>");
                userPassword = newPassword;
                user.Password = userPassword;
            }
            else if (oldPassword != userPassword)
            {
                Response.Write("<script>alert('Your old password is wrong! Please try again!');window.location.href='ChangePassword.aspx'</script>");

            }
            else
            {
                Response.Write("<script>alert('The new password not same! Please try again!');window.location.href='ChangePassword.aspx'</script>");
            }

        }
    }
}