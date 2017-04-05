using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;

namespace Assignment1.Tests
{
    [TestClass]
    public class W2Tests
    {

        [TestClass]
        public class W2Test
        {
            Game _game;


            public TestContext TestContext { get; set; }

            //1
            [TestInitialize]
            public void Setup()
            {
                _game = new Game();
            }

            //2 check login info same or not
            [TestMethod()]
            public void LoginInfo(string name, string pass)
            {
                name = "Name";
                pass = "pass";

                Assert.AreNotEqual(name, _game.Username);
                Assert.AreNotEqual(pass, _game.Password);

            }

            //3 check username and password not null
            [TestMethod()]
            public void LoginInfonotNull()
            {
                string Nname = _game.Username;
                string Npass = _game.Password;

                Assert.IsNotNull(Nname);
                Assert.IsNotNull(Npass);
            }

            //4 check login function
            [TestMethod()]
            public void LoginTest()
            {
                string username = "Name1";
                string password = "Password1";

                Assert.IsTrue(_game.Login(username, password));

            }

            //5 check return report info
            [TestMethod()]
            public void reportTest()
            {
                string reportinput = "input";
                string EreportOutput = "Output";
                string AreportOutput = _game.OutReport(reportinput);

                Assert.AreNotSame(EreportOutput, AreportOutput);
            }

            //6 check add new client function
            [TestMethod()]
            public void AddclientTest()
            {
                string Clientinfo = "info";
                string EResult = "result";
                string ClientResult = _game.AddClient(Clientinfo);

                Assert.AreNotSame(EResult, ClientResult);
            }

            


        }
    }
}
