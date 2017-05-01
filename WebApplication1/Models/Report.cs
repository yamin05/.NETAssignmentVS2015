using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Report
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string RoleName { get; set; }

        public decimal TotalHours { get; set; }

        public decimal TotalCosts { get; set; }

        public decimal AverageHours { get; set; }

        public decimal AverageCosts { get; set; }

        public decimal Hours { get; set; }

        public decimal Costs { get; set; }

        public string DistrictId { get; set; }

        public string DistrictName { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }
    }
}