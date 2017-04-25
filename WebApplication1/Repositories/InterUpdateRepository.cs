using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InterUpdateRepository : Repository<InterventionUpdate>
    {
        public InterUpdateRepository(DbContext context) : base(context)
        {
        }

        public override InterventionUpdate Delete(InterventionUpdate tentity)
        {
            throw new NotImplementedException();
        }

        public override InterventionUpdate Insert(InterventionUpdate tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO InterventionUpdate VALUES( @InterventionId,@UserId, @Condition, @ModifyDate)";
                command.Parameters.Add(command.CreateParameter("InterventionId", tentity.InterventionId));
                command.Parameters.Add(command.CreateParameter("UserId", tentity.UserId));
                command.Parameters.Add(command.CreateParameter("Condition", tentity.Condition));
                command.Parameters.Add(command.CreateParameter("ModifyDate", tentity.ModifyDate));
                
                //command.ExecuteNonQuery();
                return this.ToList(command).FirstOrDefault();
            }






        }

        public override InterventionUpdate Update(InterventionUpdate tentity)
        {
            throw new NotImplementedException();
        }

        
    }
}