using System;
using System.Linq;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InterventionTypeRepository : Repository<InterventionType>
    {
        public InterventionTypeRepository(DbContext context) : base(context) { }

        public override InterventionType Delete(InterventionType tentity)
        {
            throw new NotImplementedException();
        }

        public InterventionType GetInterventionTypeWithId(int id)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM InterventionType WHERE InterventionTypeId = @id";
                command.Parameters.Add(command.CreateParameter("id", id));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override InterventionType Insert(InterventionType tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO InterventionType VALUES(@InterventionTypeName, @InterventionTypeHour, @InterventionTypeNameCost)";
                command.Parameters.Add(command.CreateParameter("InterventionTypeName", tentity.InterventionTypeName));
                command.Parameters.Add(command.CreateParameter("InterventionTypeHour", tentity.InterventionTypeHours));
                command.Parameters.Add(command.CreateParameter("InterventionTypeNameCost", tentity.InterventionTypeCost));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override InterventionType Update(InterventionType tentity)
        {
            throw new NotImplementedException();
        }
    }
}