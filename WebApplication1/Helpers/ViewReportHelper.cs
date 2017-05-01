using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Helpers
{
    public class ViewReportHelper
    {
        private DbConnectionFactory factory;
        private DbContext context;

        public ViewReportHelper(string connectionString)
        {
            factory = new DbConnectionFactory(connectionString);
            context = new DbContext(factory);
        }
        public IList<Report> ViewTotalCostsByEngineer()
        {
            var repos = new ViewReportRepository(context);
            var list = repos.ViewTotalCostsByEngineer();
            return list;
        }

        public IList<Report> ViewAverageCostsByEngineer()
        {
            var repos = new ViewReportRepository(context);
            var list = repos.ViewAverageCostsByEngineer();
            return list;
        }

        public IList<Report> ViewCostsByDistrict()
        {
            var repos = new ViewReportRepository(context);
            var list = repos.ViewCostsByDistrict();
            return list;
        }

        public IList<Report> ViewMonthlyCostForDistrict(string districtId)
        {
            var repos = new ViewReportRepository(context);
            var list = repos.ViewMonthlyCostForDistrict(districtId);
            return list;
        }


        public Dictionary<string, int> GetDistrictForUser()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            list.Add("All District", 999);
            list.Add(Districts.Urban_Indonesia.ToString().Replace("_", " "), (int)Districts.Urban_Indonesia);
            list.Add(Districts.Rural_Indonesia.ToString().Replace("_", " "), (int)Districts.Rural_Indonesia);
            list.Add(Districts.Urban_Papua_New_Guinea.ToString().Replace("_", " "), (int)Districts.Urban_Papua_New_Guinea);
            list.Add(Districts.Rural_Papua_New_Guinea.ToString().Replace("_", " "), (int)Districts.Rural_Papua_New_Guinea);
            list.Add(Districts.Sydney.ToString().Replace("_", " "), (int)Districts.Sydney);
            list.Add(Districts.Rural_New_South_Wales.ToString().Replace("_", " "), (int)Districts.Rural_New_South_Wales);
            return list;
        }
    }
}