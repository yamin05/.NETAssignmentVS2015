using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class CreateInterventionHelper
    {
        private DbConnectionFactory factory;
        private DbContext context;
        public IList<InterventionType> intType { get; private set; }

        public CreateInterventionHelper(string connectionString)
        {
            factory = new DbConnectionFactory(connectionString);
            context = new DbContext(factory);
        }

        public IList<InterventionType> GetInterventionTypes ()
        {
            var repos = new InterventionTypeRepository(context);
            var list = repos.GetAll();
            intType = list;
            return list;
        }

        public IList<Clients> GetClientNames()
        {
            var repos = new ClientRepository(context);
            var list = repos.GetAllClientsForUser(HttpContext.Current.User.Identity.GetUserId());
            return list;
        }

        public void CreateIntervention (int interventionTypeId, int clientId, string interventionHour, string interventionCost)
        {
            var repos = new InterventionsRepository(context);
            Interventions intervention = new Interventions();
            intervention.UserId = HttpContext.Current.User.Identity.GetUserId();
            intervention.InterventionTypeId = interventionTypeId;
            intervention.ClientId = clientId;
            intervention.CreateDate = DateTime.Now;
            intervention.Status = (int) Status.Proposed;
            if (Utils.getInstance.isNullOrEmpty(interventionHour) || Utils.getInstance.isNullOrEmpty(interventionCost))
            {
                var intTypeRepo = new InterventionTypeRepository(context);
                var intType = intTypeRepo.GetInterventionTypeWithId(interventionTypeId);
                intervention.InterventionHour = (Utils.getInstance.isNullOrEmpty(interventionHour)) ?
                    intType.InterventionTypeHours : decimal.Parse(interventionHour);
                intervention.InterventionCost = (Utils.getInstance.isNullOrEmpty(interventionCost)) ?
                    intType.InterventionTypeCost : decimal.Parse(interventionCost);
            }
            try
            {
                repos.Insert(intervention);
            }
            catch (Exception ex)
            {
                throw new FailedToCreateRecordException();
            }
        }
    }
}