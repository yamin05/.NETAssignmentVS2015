using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ClientRepository : Repository<Clients>
    {
        //private DbContext _context;

        public ClientRepository(DbContext context) : base(context)
        {
            //_context = context;
        }

        public IList<Users> GetAllForUser(string userId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Users WHERE UserId = @userid";
                command.Parameters.Add(command.CreateParameter("userid", userId));
                //command.ExecuteReader();
                return ToList(command).ToList();
            }
        }

        public override Users Delete(Users tentity)
        {
            throw new NotImplementedException();
        }
        
        public override Clients Insert(Clients tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Clients VALUES(@ClientName, @ClientLocation, @ClientDistrict)";
                command.Parameters.Add(command.CreateParameter("ClientName", tentity.ClientName));
                command.Parameters.Add(command.CreateParameter("ClientLocation", tentity.ClientLocation));
                command.Parameters.Add(command.CreateParameter("ClientDistrict", tentity.ClientDistrict));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override Clients Update(Clients tentity)
        {
            throw new NotImplementedException();
        }

        public override Clients Delete(Clients tentity)
        {
            throw new NotImplementedException();
        }
    }
}