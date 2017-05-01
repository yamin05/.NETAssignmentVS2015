﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;


namespace WebApplication1.Repositories
{
    public class ViewReportRepository : Repository<Report>
    {
        public ViewReportRepository(DbContext context) : base(context) { }

        public IList<Report> ViewTotalCostsByEngineer()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT R.UserId, anu.UserName, anr.Name RoleName, R.TotalCosts, R.TotalHours
                                        FROM Report_TotalCostsByEngineer R inner join [aspnet-WebApplication1-20170404072835].[dbo].[aspnetusers] anu on anu.id=R.userid 
                                        inner join  [aspnet-WebApplication1-20170404072835].[dbo].[AspNetUserRoles] anur on anu.id=anur.userid
                                        inner join  [aspnet-WebApplication1-20170404072835].[dbo].[AspNetRoles] anr on anur.roleid=anr.id 
										where anr.Name='siteengineer' order by anu.UserName";
                return this.ToList(command).ToList();
            }
        }

        public IList<Report> ViewAverageCostsByEngineer()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT R.UserId, anu.UserName, anr.Name RoleName, R.AverageCosts, R.AverageHours
                                        FROM Report_AverageCostsByEngineer R inner join [aspnet-WebApplication1-20170404072835].[dbo].[aspnetusers] anu on anu.id=R.userid 
                                        inner join  [aspnet-WebApplication1-20170404072835].[dbo].[AspNetUserRoles] anur on anu.id=anur.userid
                                        inner join  [aspnet-WebApplication1-20170404072835].[dbo].[AspNetRoles] anr on anur.roleid=anr.id 
										where anr.Name='siteengineer' order by anu.UserName";
                return this.ToList(command).ToList();
            }
        }

        public IList<Report> ViewCostsByDistrict()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT R.DistrictId, R.DistrictName, R.Costs, R.Hours
                                        FROM Report_CostsByDistrict R ";
                return this.ToList(command).ToList();
            }
        }

        public IList<Report> ViewMonthlyCostForDistrict(string districtId)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"SELECT R.DistrictId, R.DistrictName, R.m, R.Costs, R.Hours
                                        FROM Report_MonthlyCostForDistrict R WHERE DistrictId= @DistrictId";
                command.Parameters.Add(command.CreateParameter("DistrictId", districtId));
                return this.ToList(command).ToList();
            }
        }

        public override Report Delete(Report tentity)
        {
            throw new NotImplementedException();
        }

        public override Report Insert(Report tentity)
        {
            throw new NotImplementedException();
        }

        public override Report Update(Report tentity)
        {
            throw new NotImplementedException();
        }
    }
}