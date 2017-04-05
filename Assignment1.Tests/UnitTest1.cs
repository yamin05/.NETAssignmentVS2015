using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;

namespace Assignments1.Tests
{
    [TestClass]
    public class PasswordchangerTest
    {
        public TestContext TestContext { get; set; }
       

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void OldPassWrong()
        {
            PasswordChanger Pass1 = new PasswordChanger();
            String OldPassword = "Divas";
            String Password = "Diva";
            String NewPassword = "Malik";
            String ConfirmPassword = "Malik";
            Pass1.ChangePassword(NewPassword, OldPassword, Password, ConfirmPassword);
        }

        [TestMethod()]
        public void OldPassEmpty()
        {
            PasswordChanger Pass1 = new PasswordChanger();
            String OldPassword = "";
            String Password="Divas";
            String NewPassword = "Malik";
            String ConfirmPassword = "Malik";
            Pass1.ChangePassword( NewPassword, OldPassword, Password,ConfirmPassword);
            Assert.IsNull(Pass1.oldPassword);
        }

        [TestMethod()]
        public void ConfirmPassDoesntMatchNewPass()
        {
            PasswordChanger Pass1 = new PasswordChanger();
            String ConfirmPassword = "Mal";
            String NewPassword = "Malik";
            Pass1.ConfirmPass(NewPassword, ConfirmPassword);
            Assert.AreEqual(0, Pass1.flag);
        }



    }
    }

