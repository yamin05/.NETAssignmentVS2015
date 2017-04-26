using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class CreateClientHelper
    {
        private DbConnectionFactory factory;
        private DbContext context;

        public CreateClientHelper(string connectionString)
        {
            factory = new DbConnectionFactory(connectionString);
            context = new DbContext(factory);
        }

        public IList<int> GetDistrictsForSiteManager (string userId)
        {
            var repos = new UserRepository(context);
            var rows = repos.GetAllForUser(userId);
            List<int> list = new List<int>();
            foreach(var row in rows)
            {
                list.Add(row.District);
            }
            return list;
        }

        public void CreateClient (string clientName, string clientLocation, int clientDistrict)
        {
            var clientRepo = new ClientRepository(context);
            Clients client = new Clients();
            client.ClientName = clientName;
            client.ClientLocation = clientLocation;
            client.ClientDistrict = clientDistrict;

            var clientId = clientRepo.InsertWithGetId(client);
            if (Utils.getInstance.isNullOrEmpty(clientId) || clientId == 0)
            {
                throw new FailedToCreateRecordException();
            }
            var engineerClientRepo = new EngineerClientsRepository(context);
            EngineersClients engClient = new EngineersClients();
            engClient.UserId = HttpContext.Current.User.Identity.GetUserId();
            engClient.ClientId = clientId;
            engClient.CreateDate = DateTime.Now;
            engineerClientRepo.Insert(engClient);
        }
    }
}