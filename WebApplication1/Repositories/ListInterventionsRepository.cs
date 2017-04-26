using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ListInterventionsRepository : Repository<ListInterventions>
    {
        

        public ListInterventionsRepository(DbContext context) : base(context)
        {
            
        }

        public List<ListInterventions> GetAllInterventionsForUser(string userid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT ClientName, InterventionTypeName, InterventionHours, InterventionCost,
                                            CreateDate, Status FROM Interventions inner join Clients on Interventions.ClientId = Clients.ClientId
                                            inner join InterventionType on Interventions.InterventionTypeId = InterventionType.InterventionTypeId
                                            where UserId = @userid";
                command.Parameters.Add(command.CreateParameter("userid", userid));
                return this.ToList(command).ToList();
            }
        }

        public List<ListInterventions> GetAllInterventionsForClient(string userid, int clientid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT ClientName, InterventionTypeName, InterventionHours, InterventionCost,
                                            CreateDate, Status FROM Interventions inner join Clients on Interventions.ClientId = Clients.ClientId
                                            inner join InterventionType on Interventions.InterventionTypeId = InterventionType.InterventionTypeId
                                            where Interventions.UserId = @userid and Interventions.ClientId = @clientid";
                command.Parameters.Add(command.CreateParameter("userid", userid));
                command.Parameters.Add(command.CreateParameter("clientid", clientid));
                return this.ToList(command).ToList();
            }
        }

        public override ListInterventions Insert(ListInterventions tentity)
        {
            throw new NotImplementedException();
        }

        public override ListInterventions Update(ListInterventions tentity)
        {
            throw new NotImplementedException();
        }

        public override ListInterventions Delete(ListInterventions tentity)
        {
            throw new NotImplementedException();
        }
    }
}