using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository : Repository<User>
    {
        //private DbContext _context;

        public UserRepository(DbContext context) : base(context)
        {
            //_context = context;
        }

        public IList<User> GetUsers()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[uspGetUsers]";

                return this.ToList(command).ToList();
            }
        }

        public override User Delete(User tentity)
        {
            throw new NotImplementedException();
        }

        public override User Insert(User tentity)
        {
            throw new NotImplementedException();
        }

        public override User Update(User tentity)
        {
            throw new NotImplementedException();
        }

        //public void Create(User user)
        //{
        //    using (var command = _context.CreateCommand())
        //    {
        //        command.CommandText = @"INSERT INTO Users (CompanyId, FirstName) VALUES(@companyId, @firstName)";
        //        command.AddParameter("companyId", user.CompanyId);
        //        command.AddParameter("firstName", user.FirstName);
        //        command.ExecuteNonQuery();
        //    }

        //    //todo: Get identity. Depends on the db engine.
        //}
        //public void Update(User user)
        //{
        //    using (var command = _context.CreateCommand())
        //    {
        //        command.CommandText = @"UPDATE Users SET CompanyId = @companyId WHERE DeptId = @userId";
        //        command.AddParameter("companyId", user.CompanyId);
        //        command.AddParameter("userId", user.DeptId);
        //        command.ExecuteNonQuery();
        //    }
        //}
        //public void Delete(int id)
        //{
        //    using (var command = _context.CreateCommand())
        //    {
        //        command.CommandText = @"DELETE FROM Users WHERE DeptId = @userId";
        //        command.AddParameter("userId", id);
        //        command.ExecuteNonQuery();
        //    }
        //}

        //public IEnumerable<User> FindUsers(string firstName)
        //{
        //    using (var command = _context.CreateCommand())
        //    {
        //        command.CommandText = @"SELECT * FROM Users WHERE CompanyId = @companyId AND FirstName LIKE @firstName";
        //        command.AddParameter("companyId", LoggedInUser.companyId);
        //        command.AddParameter("firstName", firstName + "%");
        //        return ToList(command);
        //    }
        //}

        //public IEnumerable<User> FindBlocked()
        //{
        //    using (var command = _context.CreateCommand())
        //    {
        //        command.CommandText = @"SELECT * FROM Users WHERE Status = -1";
        //        return ToList(command);
        //    }
        //}

        //protected void Fill(IDataRecord record, User user)
        //{
        //    user.FirstName = (string)record["FirstName"];
        //    user.Age = (int)record["Age"];
        //}
    }
}