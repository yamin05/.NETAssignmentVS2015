using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class ChangeDistrictsHelper
    {
        private DbConnectionFactory factory;
        private DbContext context;
        private UserDetail userDetail = new UserDetail();

        public ChangeDistrictsHelper(string connectionString)
        {
            factory = new DbConnectionFactory(connectionString);
            context = new DbContext(factory);
        }

        public void ChangeDistricts(string userId, string oldDistrict, int newDistrict)
        {
            userDetail.UserId = userId;
            var userDetailRepo = new UserDetailRepository(context);
            userDetail = userDetailRepo.GetUserWithUserId(userDetail.UserId);
            //var oldDistrictText = (int)Enum.Parse(typeof(Districts), oldDistrict.Replace(" ","_"));
            //var newDistrictText = Convert.ToInt32(newDistrict);
            //var newDistrictText = (int)Enum.Parse(typeof(Districts), newDistrict.Replace(" ", "_"));
            var oldDistrictText = Convert.ToInt32(oldDistrict);
            var repo = new UserDetailRepository(context);
            var row = repo.ChangeUserDistrict(userDetail.UserId, oldDistrictText, newDistrict);
        }


        public Dictionary<string, int> GetDistrictForUser()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();      
            list.Add(Districts.Urban_Indonesia.ToString().Replace("_"," "), (int)Districts.Urban_Indonesia);
            list.Add(Districts.Rural_Indonesia.ToString().Replace("_", " "), (int)Districts.Rural_Indonesia);
            list.Add(Districts.Urban_Papua_New_Guinea.ToString().Replace("_", " "), (int)Districts.Urban_Papua_New_Guinea);
            list.Add(Districts.Rural_Papua_New_Guinea.ToString().Replace("_", " "), (int)Districts.Rural_Papua_New_Guinea);
            list.Add(Districts.Sydney.ToString().Replace("_", " "), (int)Districts.Sydney);
            list.Add(Districts.Rural_New_South_Wales.ToString().Replace("_", " "), (int)Districts.Rural_New_South_Wales);
            return list;
        }
    }
}