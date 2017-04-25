using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var repos = new ClientRepository(context);
            Clients client = new Clients();
            client.ClientName = clientName;
            client.ClientLocation = clientLocation;
            client.ClientDistrict = clientDistrict;
            repos.Insert(client);
        }
    }
}