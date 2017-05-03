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
            Users MockUser = new Users();
            ListInterventionForManager Intervention1 = new ListInterventionForManager();
            List<ListInterventionForManager> interventionListMock = new List<ListInterventionForManager>();
            MockUser.District = Convert.ToInt32(Districts.Sydney);
            MockUser.MaximumCost = 200;
            MockUser.MaximumHours = 10;
            Intervention1.InterventionCost = 180;
            Intervention1.InterventionHours = 10;
            Intervention1.District = Convert.ToInt32(Districts.Sydney);
            interventionListMock.Add(Intervention1);
            var list2 = interventionListMock;
            var list = new ListInterventionsHelper();
            var list1= list.ValidateProposedInterventions(MockUser, interventionListMock);
            Collection<ListInterventionForManager> collection = new Collection<ListInterventionForManager>(list1);
            CollectionAssert.AreEqual(collection, list2);
        }
    }
}
  
