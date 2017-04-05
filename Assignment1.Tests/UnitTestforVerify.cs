using System;
using WebApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1.Tests
{
    [TestClass]
    public class VerifyTest
    {
        /* From Qing */
        //1
            Verify _v;

            [TestInitialize]
            public void Setup()
            {
                Verify _v = new Verify();
            }

            //2 check login info same or not
            [TestMethod()]
            public void LoginInfo(string name, string pass)
            {
                name = "Name";
                pass = "pass";

                Assert.AreEqual(name, _v.Username);
                Assert.AreEqual(pass, _v.Password);
                
            }

            //3 check username and password not null
            [TestMethod()]
            public void LoginInfonotNull()
            {
                string Nname = _v.Username;
                string Npass = _v.Password;

                Assert.IsNull(Nname);
                Assert.IsNull(Npass);
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
            public void reportTest()
            {
                string reportinput = "input";
                string EreportOutput = "Output";
                string AreportOutput = _v.OutReport(reportinput);

                Assert.AreSame(EreportOutput, AreportOutput);
            }

            //6 check add new client function
            [TestMethod()]
            public void AddclientTest()
            {
                string Clientinfo ="info";
                string EResult = "result";
                string ClientResult = _v.AddClient(Clientinfo);

                Assert.AreSame(EResult, ClientResult);
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



    }
}
