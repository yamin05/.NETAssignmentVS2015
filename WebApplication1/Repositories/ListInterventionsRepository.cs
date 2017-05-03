using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ListInterventionsRepository : Repository<ListInterventions>
    {
        public ListInterventionsRepository(DbContext context) : base(context) { }

        public List<ListInterventions> GetAllInterventionsForUser(string userid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT ClientName, InterventionId, InterventionTypeName, InterventionHours, InterventionCost,
                                            CreateDate, Status FROM Interventions inner join Clients on Interventions.ClientId = Clients.ClientId
                                            inner join InterventionType on Interventions.InterventionTypeId = InterventionType.InterventionTypeId
                                            where UserId = @userid and Status != @status";
                command.Parameters.Add(command.CreateParameter("userid", userid));
                command.Parameters.Add(command.CreateParameter("status", (int)Status.Cancelled));
                return this.ToList(command).ToList();
            }
        }

        public List<ListInterventions> GetAllInterventionsForClient(string userid, int clientid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT ClientName, InterventionId, tb.UserName, InterventionTypeName, InterventionHours, InterventionCost, CreateDate, Status FROM Interventions 
                                            inner join Clients on Interventions.ClientId = Clients.ClientId
                                            inner join InterventionType on Interventions.InterventionTypeId = InterventionType.InterventionTypeId
                                            inner join [aspnet-WebApplication1-20170404072835].[dbo].[AspNetUsers] as tb on Interventions.UserId = tb.Id
                                            where Interventions.UserId = @userid and Interventions.ClientId = @clientid and Status != @status";
                command.Parameters.Add(command.CreateParameter("userid", userid));
                command.Parameters.Add(command.CreateParameter("clientid", clientid));
                command.Parameters.Add(command.CreateParameter("status", (int)Status.Cancelled));
                return this.ToList(command).ToList();
            }
        }

        public List<ListInterventions> GetAllInterventionsForClientInSameDistrict(int clientid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT ClientName, InterventionId, tb.UserName, InterventionTypeName, InterventionHours, InterventionCost, CreateDate, Status FROM Interventions 
                                            inner join Clients on Interventions.ClientId = Clients.ClientId
                                            inner join InterventionType on Interventions.InterventionTypeId = InterventionType.InterventionTypeId
                                            inner join [aspnet-WebApplication1-20170404072835].[dbo].[AspNetUsers] as tb on Interventions.UserId = tb.Id
                                            where Interventions.ClientId = @clientid and Status != @status";
                command.Parameters.Add(command.CreateParameter("clientid", clientid));
                command.Parameters.Add(command.CreateParameter("status", (int)Status.Cancelled));
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