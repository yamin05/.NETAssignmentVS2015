using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class ViewUsersHelper
    {
        private DbConnectionFactory factory;
        private DbContext context;
        private DbConnectionFactory factory1;
        private DbContext context1;

        public ViewUsersHelper(string connectionString, string connectionString1)
        {
            factory = new DbConnectionFactory(connectionString);
            context = new DbContext(factory);
            factory1 = new DbConnectionFactory(connectionString1);
            context1 = new DbContext(factory1);
        }


        public IList<Users> GetAllUsers()
        {
            var repos = new UserRepository(context);
            var list = repos.GetAllUsers();
            return list;
        }
    }
}