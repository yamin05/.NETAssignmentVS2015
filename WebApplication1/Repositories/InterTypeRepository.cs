using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InterTypeRepository : Repository<InterventionType>
    {
        public InterTypeRepository(DbContext context) : base(context)
        {
        }

        public override InterventionType Delete(InterventionType tentity)
        {
            throw new NotImplementedException();
        }

        public override InterventionType Insert(InterventionType tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO InterventionType VALUES(@InterventionTypeName, @InterventionTypeHour, @InterventionTypeNameCost)";
                //command.Parameters.Add(command.CreateParameter("InterventionId", tentity.InterventionId));
                command.Parameters.Add(command.CreateParameter("InterventionTypeName", tentity.InterventionTypeName));
                command.Parameters.Add(command.CreateParameter("InterventionTypeHour", tentity.InterventionTypeHour));
                command.Parameters.Add(command.CreateParameter("InterventionTypeNameCost", tentity.InterventionTypeCost));
                //command.ExecuteNonQuery();
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override InterventionType Update(InterventionType tentity)
        {
            throw new NotImplementedException();
        }
    }
}