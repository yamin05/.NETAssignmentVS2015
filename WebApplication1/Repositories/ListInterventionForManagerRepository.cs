using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ListInterventionForManagerRepository : Repository<ListInterventionForManager>
    {
  
     
            public ListInterventionForManagerRepository(DbContext context) : base(context)
            {

            }

            public List<ListInterventionForManager> GetAllProposedInterventiond()
            {
                using (var command = _context.CreateCommand())
                {
                    command.CommandText = @"SELECT District,ClientDistrict,ClientName, InterventionTypeName, InterventionHours, InterventionCost,
                                            CreateDate,Status,InterventionId FROM Interventions inner join Clients on Interventions.ClientID = Clients.ClientId
                                            inner join InterventionType on Interventions.InterventionTypeId = InterventionType.InterventionTypeId 
                                            inner join Users on Interventions.UserId = Users.UserId where Interventions.Status = @Proposed";

                command.Parameters.Add(command.CreateParameter("Proposed",(int)Status.Proposed));
                return this.ToList(command).ToList();
                }
            }

        public List<ListInterventionForManager> GetAllInterventionAssociatedWithManager(string userid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT District,ClientDistrict,ClientName, InterventionTypeName, InterventionHours, InterventionCost,
                                            CreateDate,Status,InterventionId FROM Interventions inner join Clients on Interventions.ClientID = Clients.ClientId
                                            inner join InterventionType on Interventions.InterventionTypeId = InterventionType.InterventionTypeId 
                                            inner join Users on Interventions.UserId = Users.UserId where Interventions.Operator = @userid";

                command.Parameters.Add(command.CreateParameter("userid", userid));
                return this.ToList(command).ToList();
            }
        }

        public List<ListInterventionForManager> GetAllInterventionByInterventionId(int interventionid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT District,ClientDistrict,ClientName, InterventionTypeName, InterventionHours, InterventionCost,
                                            CreateDate,Status,InterventionId FROM Interventions inner join Clients on Interventions.ClientID = Clients.ClientId
                                            inner join InterventionType on Interventions.InterventionTypeId = InterventionType.InterventionTypeId 
                                            inner join Users on Interventions.UserId = Users.UserId where Interventions.InterventionId=@interventionid";
                command.Parameters.Add(command.CreateParameter("interventionid", interventionid));
                return this.ToList(command).ToList();
            }
        }

        public override ListInterventionForManager Insert(ListInterventionForManager tentity)
        {
            throw new NotImplementedException();
        }

        public override ListInterventionForManager Update(ListInterventionForManager tentity)
        {
            throw new NotImplementedException();
        }

        public override ListInterventionForManager Delete(ListInterventionForManager tentity)
        {
            throw new NotImplementedException();
        }
    }
    }