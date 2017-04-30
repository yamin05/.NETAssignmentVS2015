using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserDetailRepository : Repository<UserDetail>
    {
        public UserDetailRepository(DbContext context) : base(context) { }

        public IList<UserDetail> GetAllUsers()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT u.UserId, anu.UserName, anr.Name RoleName, u.MaximumCost,u.MaximumHours, 
                                        u.District
                                        FROM Users u inner join [aspnet-WebApplication1-20170404072835].[dbo].[aspnetusers] anu on anu.id=u.userid 
                                        inner join  [aspnet-WebApplication1-20170404072835].[dbo].[AspNetUserRoles] anur on anu.id=anur.userid
                                        inner join  [aspnet-WebApplication1-20170404072835].[dbo].[AspNetRoles] anr on anur.roleid=anr.id 
										where anr.Name='siteengineer' or anr.Name='manager' ";
                //command.Parameters.Add(command.CreateParameter("userid", userId));
                return this.ToList(command).ToList();
                
                                        //,case when u.District = '1' then 'Urban Indonesia'
                                        //when u.District = '2' then 'Rural Indonesia'
                                        //when u.District = '3' then 'Urban Papua New Guinea'
                                        //when u.District = '4' then 'Rural Papua New Guinea'
                                        //when u.District = '5' then 'Sydney'
                                        //when u.District = '6' then 'Rural New South Wales' end DistrictName
            }
        }

        public override UserDetail Delete(UserDetail tentity)
        {
            throw new NotImplementedException();
        }

        public override UserDetail Insert(UserDetail tentity)
        {
            throw new NotImplementedException();
        }

        public override UserDetail Update(UserDetail tentity)
        {
            throw new NotImplementedException();
        }


        public UserDetail ChangeUserDistrict(string userId, int oldDistrict, int newDistrict)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = command.CommandText = @"UPDATE Users SET District = @newDistrict 
                                                                WHERE District = @oldDistrict and userId = @userId";
                command.Parameters.Add(command.CreateParameter("newDistrict", newDistrict));
                command.Parameters.Add(command.CreateParameter("oldDistrict", oldDistrict));
                command.Parameters.Add(command.CreateParameter("userId", userId));
                return this.ToList(command).FirstOrDefault();
            }
        }

        public UserDetail GetUserWithUserId(string userId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Users where userId = @userId";
                command.Parameters.Add(command.CreateParameter("userId", userId));
                return this.ToList(command).FirstOrDefault();
            }
        }

    }
}