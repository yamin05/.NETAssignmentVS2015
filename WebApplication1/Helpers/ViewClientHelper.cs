using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class ViewClientHelper
    {
        private DbConnectionFactory factory;
        private DbContext context;

        public ViewClientHelper(string connectionString)
        {
            factory = new DbConnectionFactory(connectionString);
            context = new DbContext(factory);
        }

        public IList<Clients> GetAllClients ()
        {
            var repos = new ClientRepository(context);
            var list = repos.GetAllClientsForUser(HttpContext.Current.User.Identity.GetUserId());
            return list;
        }

        public IList<Clients> GetAllClientsInSameDistrict()
        {
            var repos = new ClientRepository(context);
            var list = repos.GetAllClientsForUser(HttpContext.Current.User.Identity.GetUserId());
            return list;
        }
    }
}