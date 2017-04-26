using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class EngineerClientsRepository : Repository<EngineersClients>
    {
        public EngineerClientsRepository(DbContext context) : base(context) { }

        public override EngineersClients Delete(EngineersClients tentity)
        {
            throw new NotImplementedException();
        }

        public override EngineersClients Insert(EngineersClients tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO EngineersClients VALUES(@UserId, @ClientId, @CreateDate)";
                command.Parameters.Add(command.CreateParameter("UserId", tentity.UserId));
                command.Parameters.Add(command.CreateParameter("CreateDate", tentity.CreateDate));
                command.Parameters.Add(command.CreateParameter("ClientId", tentity.ClientId));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override EngineersClients Update(EngineersClients tentity)
        {
            throw new NotImplementedException();
        }
    }
}