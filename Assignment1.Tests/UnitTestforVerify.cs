using System;
using WebApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.For_Test_Purpose;
using WebApplication1.Exceptions;

namespace Assignment1.Tests
{
    [TestClass]
    public class UnitTestforVerify
    {
        /* From Qing */
        //1
        Verify _v;

        [TestInitialize]
            public void Setup()
            {
            Verify verify = new Verify();
            _v = verify;
        }

        //2 check login info same or not
        [TestMethod()]
        public void LoginInfo()
        {
            string name = "Name";
            string pass = "pass";

            Assert.AreNotEqual(name, _v.Username);
            Assert.AreNotEqual(pass, _v.Password);
                
        }

        //3 check username and password not null
        [TestMethod()]
        public void LoginInfoNotNull()
        {
            string Nname = _v.Username;
            string Npass = _v.Password;
            
            Assert.IsNotNull(Nname);
            Assert.IsNotNull(Npass);
        }

        //4 check login function
        [TestMethod()]
        public void LoginTest()
        {
            string username = "Name1";
            string password = "Password1";

            Assert.IsTrue(_v.Login(username, password));

        }

        //5 check return report info
        [TestMethod()]
        public void ReportTest()
        {
            string reportinput = "input";
            string EreportOutput = "Output";
            string AreportOutput = _v.OutReport(reportinput);

            Assert.AreNotSame(EreportOutput, AreportOutput);
        }

        //6 check add new client function
        [TestMethod()]
        public void AddClientTest()
        {
            string Clientinfo ="info";
            string EResult = "result";
            string ClientResult = _v.AddClient(Clientinfo);

            Assert.AreNotSame(EResult, ClientResult);
        }


        [TestMethod]
        public void VerifyUsername()
        {
            string username = "admin";
            bool verifyFlag = true;
            if (!Verify.VerifyUsername(username))
            {
                verifyFlag = false;
            }
            bool expected = true;
            Assert.AreEqual(expected.ToString(), verifyFlag.ToString());
        }

        [TestMethod]
        public void VerifyName()
        {
            string lastname = "Zhang";
            string firstname = "Yuxiang";
            bool verifyFlag = true;
            if (!Verify.VerifyName(firstname, lastname))
            {
                verifyFlag = false;
            }
            bool expected = true;
            Assert.AreEqual(expected.ToString(), verifyFlag.ToString());
        }

        [TestMethod]
        public void VerifyEngineerLimit()
        {
            decimal interventionhour = 50;
            decimal interventioncost = 2000;
            bool verifyFlag = true;
            if (!Verify.VerifyEngineerLimit(interventionhour, interventioncost))
            {
                verifyFlag = false;
            }
            bool expected = true;
            Assert.AreEqual(expected.ToString(), verifyFlag.ToString());
        }

        [TestClass]
        public class PasswordChangerTest
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
                String Password = "Divas";
                String NewPassword = "Malik";
                String ConfirmPassword = "Malik";
                Pass1.ChangePassword(NewPassword, OldPassword, Password, ConfirmPassword);
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

            //From Yamin
            [TestMethod]
            public void HoursNotExcedingAllowedHoursTest()
            {
                double allocatedHours = 10;
                var testObject = new UnitTestLogics();
                testObject.AllocateHours(allocatedHours);
                double result = testObject.allocatedHours;
                Assert.AreEqual(result, allocatedHours);
            }

            [TestMethod]
            [ExpectedException(typeof(ExcedesAllowedHoursException))]
            public void HoursExcidingAllowedHoursTest()
            {
                double allocatedHours = 1000;
                var testObject = new UnitTestLogics();
                try
                {
                    testObject.AllocateHours(allocatedHours);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }

            [TestMethod]
            public void CostNotExcedingAllowedCostTest()
            {
                double allocatedCost = 10;
                var testObject = new UnitTestLogics();
                testObject.AllocateCost(allocatedCost);
                double result = testObject.allocatedCost;
                Assert.AreEqual(result, allocatedCost);
            }

            [TestMethod]
            [ExpectedException(typeof(ExcedesAllowedCostException))]
            public void CostExcidingAllowedCostTest()
            {
                double allocatedCost = 1000;
                var testObject = new UnitTestLogics();
                try
                {
                    testObject.AllocateCost(allocatedCost);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }


        }
    }

}

