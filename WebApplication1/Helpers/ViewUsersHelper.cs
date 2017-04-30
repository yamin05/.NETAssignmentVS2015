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

        public ViewUsersHelper(string connectionString)
        {
            factory = new DbConnectionFactory(connectionString);
            context = new DbContext(factory);
        }


        public IList<UserDetail> GetAllUsers()
        {
            var repos = new UserDetailRepository(context);
            var list = repos.GetAllUsers();
            return list;
        }
    }
}