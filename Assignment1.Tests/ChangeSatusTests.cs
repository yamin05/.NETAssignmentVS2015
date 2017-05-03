using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Exceptions;

namespace Assignment1.Tests
{
    [TestClass]
    public class ChangeSatusTests
    {
        [TestMethod]
        [ExpectedException(typeof(EditStatusPermissionException))]
        public void TestStatusChnageEditException()
        {

        }
    }
}
