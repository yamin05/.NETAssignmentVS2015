using System;
using WebApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1.Tests
{
    [TestClass]
    public class VerifyTest
    {
        

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
