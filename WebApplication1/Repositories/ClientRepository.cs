using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ClientRepository : Repository<Clients>
    {
        public ClientRepository(DbContext context) : base(context) { }
        
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

        public int InsertWithGetId(Clients tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Clients VALUES(@ClientName, @ClientLocation, @ClientDistrict); Select Scope_Identity()";
                command.Parameters.Add(command.CreateParameter("ClientName", tentity.ClientName));
                command.Parameters.Add(command.CreateParameter("ClientLocation", tentity.ClientLocation));
                command.Parameters.Add(command.CreateParameter("ClientDistrict", tentity.ClientDistrict));
                var column = Convert.ToInt32(command.ExecuteScalar());
                return column;
            }
        }

        public IList<Clients> GetAllClientsForUser(string userId, int district)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM EngineersClients inner join Clients on EngineersClients.ClientId = 
                                            Clients.ClientId WHERE EngineersClients.UserId = @userid and Clients.ClientDistrict = @district";
                command.Parameters.Add(command.CreateParameter("userid", userId));
                command.Parameters.Add(command.CreateParameter("district", district));
                return this.ToList(command).ToList();
            }
        }

        public IList<Clients> GetAllClientsCreatedByUser(string userId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM EngineersClients inner join Clients on EngineersClients.ClientId = 
                                            Clients.ClientId WHERE EngineersClients.UserId = @userid";
                command.Parameters.Add(command.CreateParameter("userid", userId));
                return this.ToList(command).ToList();
            }
        }

        public IList<Clients> GetAllClientsInSameDistrict(string userId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Clients inner join Users on Clients.ClientDistrict = 
                                            Users.District WHERE Users.UserId = @userid";
                command.Parameters.Add(command.CreateParameter("userid", userId));
                return this.ToList(command).ToList();
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