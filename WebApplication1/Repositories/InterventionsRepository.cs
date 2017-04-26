﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InterventionsRepository : Repository<Interventions>
    {
        

        public InterventionsRepository(DbContext context) : base(context)
        {
            
        }

        public override Interventions Insert(Interventions intervention)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Departments VALUES(@InterventionId,@UserId,@InterventionTypeId,@ClientId,@InterventionCost
                                                                       ,@InterventionHour ,@CreateDate,@Operater)";
                command.Parameters.Add(command.CreateParameter("InterventionId", intervention.InterventionId));
                command.Parameters.Add(command.CreateParameter("UserId", intervention.UserId));
                command.Parameters.Add(command.CreateParameter("InterventionTypeId", intervention.InterventionTypeId));
                command.Parameters.Add(command.CreateParameter("ClientId", intervention.ClientId));
                command.Parameters.Add(command.CreateParameter("InterventionCost", intervention.InterventionCost));
                command.Parameters.Add(command.CreateParameter("IInterventionHour", intervention.InterventionHour));
                command.Parameters.Add(command.CreateParameter("CreateDate", intervention.CreateDate));
                command.Parameters.Add(command.CreateParameter("Operater", intervention.Operater));
                
                return this.ToList(command).FirstOrDefault();
            }
        }

        public Interventions Update_Intervention_Status_As_Proposed(Interventions intervention)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = command.CommandText = @"UPDATE Interventions SET Status = @Status WHERE userid= @userid and @interventionId ";
                command.Parameters.Add(command.CreateParameter("userid", intervention.UserId));
                command.Parameters.Add(command.CreateParameter("status=1", intervention.Status));
                return this.ToList(command).FirstOrDefault();
            }
        }
        public Interventions Update_Intervention_Status_As_Approved(Interventions intervention)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = command.CommandText = @"UPDATE Interventions SET Status = @Status WHERE userid= @userid and @interventionId";
                command.Parameters.Add(command.CreateParameter("userid", intervention.UserId));
                command.Parameters.Add(command.CreateParameter("status=2", intervention.Status));
                command.Parameters.Add(command.CreateParameter("InterventionId", intervention.InterventionId));
                return this.ToList(command).FirstOrDefault();
            }
        }
        public Interventions Update_Intervention_Status_As_Cancelled(Interventions intervention)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = command.CommandText = @"UPDATE Interventions SET Status = @Status WHERE userid= @userid and @InterventionId";
                command.Parameters.Add(command.CreateParameter("userid", intervention.UserId));
                command.Parameters.Add(command.CreateParameter("Status=3", intervention.Status));
                command.Parameters.Add(command.CreateParameter("InterventionId", intervention.InterventionId));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override Interventions Delete(Interventions intervention)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Interventions WHERE InterventionId = @InterventionId";
                command.Parameters.Add(command.CreateParameter("InterventionId", intervention.InterventionId));
                //command.ExecuteNonQuery();
                return this.ToList(command).FirstOrDefault();
            }
        }

        public IEnumerable<Interventions> GetAllInterventions()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Interventions where Status= 1";
                return ToList(command);
            }
        }

        public override Interventions Update(Interventions tentity)
        {
            throw new NotImplementedException();
        }
    }
}