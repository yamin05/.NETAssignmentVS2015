using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class DeptRepository : Repository<Departments>
    {
        //private DbContext _context;

        public DeptRepository(DbContext context) : base(context)
        {
            //_context = context;
        }

        //public IList<Departments> GetDepts()
        //{
        //    using (var command = _context.CreateCommand())
        //    {
        //        command.CommandText = "exec [dbo].[Departments]";

        //        return this.ToList(command).ToList();
        //    }
        //}

        //public void Create(Departments department)
        //{
        //    using (var command = _context.CreateCommand())
        //    {
        //        command.CommandText = @"INSERT INTO Departments (CompanyId, FirstName) VALUES(@companyId, @firstName)";
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

        //protected override IList<Departments> GetAll()
        //{
            
        //}

        public override Departments Insert(Departments tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"INSERT INTO Departments VALUES(@Name)";
                command.Parameters.Add(command.CreateParameter("Name", tentity.DeptName));
                //command.ExecuteNonQuery();
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override Departments Update(Departments tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"UPDATE Departments SET Name = @name WHERE DeptId = @id";
                command.Parameters.Add(command.CreateParameter("name", tentity.DeptName));
                command.Parameters.Add(command.CreateParameter("id", tentity.DeptId));
                //command.ExecuteNonQuery();
                return this.ToList(command).FirstOrDefault();
            }
        }

        public override Departments Delete(Departments tentity)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"DELETE FROM Departments WHERE Name = @name";
                command.Parameters.Add(command.CreateParameter("name", tentity.DeptName));
                //command.ExecuteNonQuery();
                return this.ToList(command).FirstOrDefault();
            }
        }
    }
}