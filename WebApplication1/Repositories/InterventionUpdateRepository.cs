using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InterventionUpdateRepository : Repository<InterventionUpdate>
    {
        public InterventionUpdateRepository(DbContext context) : base(context) { }

        public override InterventionUpdate Delete(InterventionUpdate tentity)
        {
            throw new NotImplementedException();
        }

        public InterventionUpdate GetLastInterventionUpdateWithInterventionId(int intId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM InterventionUpdate WHERE InterventionId = @intid ORDER BY ModifyDate ASC";
                command.Parameters.Add(command.CreateParameter("intid", intId));
                return this.ToList(command).LastOrDefault();
            }
        }

        public IList<InterventionUpdate> GetAllInterventionUpdateWithInterventionId(int intId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM InterventionUpdate WHERE InterventionId = @intid ORDER BY ModifyDate ASC";
                command.Parameters.Add(command.CreateParameter("intid", intId));
                return this.ToList(command).ToList();
            }
        }

        public override InterventionUpdate Insert(InterventionUpdate tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO InterventionUpdate VALUES( @InterventionId, @UserId, @Condition, @ModifyDate, @InterventionCommnets)";
                command.Parameters.Add(command.CreateParameter("InterventionId", tentity.InterventionId));
                command.Parameters.Add(command.CreateParameter("UserId", tentity.UserId));
                command.Parameters.Add(command.CreateParameter("Condition", tentity.Condition));
                command.Parameters.Add(command.CreateParameter("ModifyDate", tentity.ModifyDate));
                command.Parameters.Add(command.CreateParameter("InterventionCommnets", tentity.InterventionComments));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override InterventionUpdate Update(InterventionUpdate tentity)
        {
            throw new NotImplementedException();
        }     
    }
}