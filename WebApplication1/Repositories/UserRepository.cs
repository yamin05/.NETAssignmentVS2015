using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository : Repository<Users>
    {

        public UserRepository(DbContext context) : base(context) { }

        public Users GetAllForUser(string userId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Users WHERE UserId = @userid";
                command.Parameters.Add(command.CreateParameter("userid", userId));
                return ToList(command).FirstOrDefault();
            }
        }

        public override Users Delete(Users tentity)
        {
            throw new NotImplementedException();
        }

        public override Users Insert(Users tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Users VALUES(@UserId, @MaximumHours, @MaximumCost, @District)";
                command.Parameters.Add(command.CreateParameter("UserId", tentity.UserId));
                command.Parameters.Add(command.CreateParameter("MaximumHours", tentity.MaximumHours));
                command.Parameters.Add(command.CreateParameter("MaximumCost", tentity.MaximumCost));
                command.Parameters.Add(command.CreateParameter("District", tentity.District));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override Users Update(Users tentity)
        {
            throw new NotImplementedException();
        }

       
    }
}