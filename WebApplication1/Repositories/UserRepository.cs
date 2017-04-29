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

        public IList<Users> GetAllUsers()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT u.UserId, anu.UserName, anr.Name RoleName, u.MaximumCost,u.MaximumHours, 
                                        u.District,
                                        case when u.District='1' then 'Urban Indonesia'
                                        when u.District='2' then 'Rural Indonesia'
                                        when u.District='3' then 'Urban Papua New Guinea'
                                        when u.District='4' then 'Rural Papua New Guinea'
                                        when u.District='5' then 'Sydney'
                                        when u.District='6' then 'Rural New South Wales' end DistrictName 
                                        FROM Users u inner join [aspnet-WebApplication1-20170404072835].[dbo].[aspnetusers] anu on anu.id=u.userid 
                                        inner join  [aspnet-WebApplication1-20170404072835].[dbo].[AspNetUserRoles] anur on anu.id=anur.userid
                                        inner join  [aspnet-WebApplication1-20170404072835].[dbo].[AspNetRoles] anr on anur.roleid=anr.id 
										where anr.Name='siteengineer' or anr.Name='manager' ";
                //command.Parameters.Add(command.CreateParameter("userid", userId));
                return this.ToList(command).ToList();
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