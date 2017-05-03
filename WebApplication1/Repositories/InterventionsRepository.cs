using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InterventionsRepository : Repository<Interventions>
    {
        public InterventionsRepository(DbContext context) : base(context) { }

        public override Interventions Insert(Interventions tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Interventions VALUES(@UserId, @InterventionTypeId, @ClientId, @InterventionCost, 
                                        @InterventionHours, @CreateDate, @Status, @Operator)";
                command.Parameters.Add(command.CreateParameter("UserId", tentity.UserId));
                command.Parameters.Add(command.CreateParameter("InterventionTypeId", tentity.InterventionTypeId));
                command.Parameters.Add(command.CreateParameter("ClientId", tentity.ClientId));
                command.Parameters.Add(command.CreateParameter("InterventionCost", tentity.InterventionCost));
                command.Parameters.Add(command.CreateParameter("InterventionHours", tentity.InterventionHours));
                command.Parameters.Add(command.CreateParameter("CreateDate", tentity.CreateDate));
                command.Parameters.Add(command.CreateParameter("Status", tentity.Status));
                command.Parameters.Add(command.CreateParameter("Operator", tentity.Operator));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public Interventions Update_Intervention_Status(int InterventionId,int OldStatus, int NewStatus, string Userid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = command.CommandText = @"UPDATE Interventions SET Status = @status,Operator=@operator WHERE InterventionId= @interventionId and Status=@oldStatus";
                command.Parameters.Add(command.CreateParameter("oldstatus", OldStatus));
                command.Parameters.Add(command.CreateParameter("status", NewStatus));
                command.Parameters.Add(command.CreateParameter("operator", Userid));
                command.Parameters.Add(command.CreateParameter("interventionId", InterventionId));
                command.ExecuteNonQuery();
                return this.ToList(command).FirstOrDefault();
            }
        }

        public Interventions Update_Intervention_Status_As_Cancelled(int interventionid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = command.CommandText = @"UPDATE Interventions SET Status = @status WHERE InterventionId= @interventionId";
                command.Parameters.Add(command.CreateParameter("status", 2));
                command.Parameters.Add(command.CreateParameter("InterventionId", interventionid));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public Interventions UpdateInterventionStatus(int intId, int oldStatus, int newStatus)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = command.CommandText = @"UPDATE Interventions SET Status = @newStatus 
                                                                WHERE Status = @oldStatus and InterventionId = @intid";
                command.Parameters.Add(command.CreateParameter("newStatus", newStatus));
                command.Parameters.Add(command.CreateParameter("oldStatus", oldStatus));
                command.Parameters.Add(command.CreateParameter("intid", intId));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public Interventions Delete(int InterventionId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = command.CommandText = @"UPDATE Interventions SET Status = @status WHERE InterventionId= @interventionId";
               
                command.Parameters.Add(command.CreateParameter("status", (int)Status.Cancelled));
                command.Parameters.Add(command.CreateParameter("InterventionId", InterventionId));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public IList<Interventions> GetInterventionsWithStatus(int status)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Interventions a inner join aspnetusers b on a.userid=b.id  where Status = @status";
                command.Parameters.Add(command.CreateParameter("status", status));
                return this.ToList(command).ToList();
            }
        }

        public Interventions GetInterventionWithInterventionId(int intId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Interventions where InterventionId = @intid";
                command.Parameters.Add(command.CreateParameter("intid", intId));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public Interventions GetInterventionForClientInSameDistrict(int intId, string userid)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Interventions 
                                            inner join Clients on Interventions.ClientId = Clients.ClientId
                                            inner join Users on Clients.ClientDistrict = Users.District
                                            where Interventions.InterventionId = @intid
                                            and Users.UserId = @userid";
                command.Parameters.Add(command.CreateParameter("intid", intId));
                command.Parameters.Add(command.CreateParameter("userid", userid));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override Interventions Update(Interventions tentity)
        {
            throw new NotImplementedException();
        }

        public override Interventions Delete(Interventions tentity)
        {
            throw new NotImplementedException();
        }
    }
}