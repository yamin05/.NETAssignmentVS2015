using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Helpers;
using Moq;
using WebApplication1.Interfaces;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1;
using System.Collections;
using System.Collections.ObjectModel;

namespace Assignment1.Tests
{
    [TestClass]
    public class ListInterventionTests
    {
        [TestMethod]
        public void ListInterventionsHelper()
        {
            Mock<Users> MockUser = new Mock<Users>();
            Mock<ListInterventionForManager> Intervention1 = new Mock<ListInterventionForManager>();
            List<ListInterventionForManager> interventionListMock = new List<ListInterventionForManager>();
            MockUser.Object.District = Convert.ToInt32(Districts.Sydney);
            MockUser.Object.MaximumCost = 200;
            MockUser.Object.MaximumHours = 10;
            Intervention1.Object.InterventionCost = 180;
            Intervention1.Object.InterventionHours = 10;
            Intervention1.Object.District = Convert.ToInt32(Districts.Sydney);
            interventionListMock.Add(Intervention1.Object);
            var list2 = interventionListMock;
            var list = new ListInterventionsHelper();
            var list1= list.ValidateProposedInterventions(MockUser.Object, interventionListMock);
            Collection<ListInterventionForManager> collection = new Collection<ListInterventionForManager>(list1);
            CollectionAssert.AreEqual(collection, list2);

        }
    }
}
  
