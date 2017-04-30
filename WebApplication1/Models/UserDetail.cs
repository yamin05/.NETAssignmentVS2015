using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserDetail
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string RoleName { get; set; }

        public decimal MaximumHours { get; set; }

        public decimal MaximumCost { get; set; }

        public int District { get; set; }

        public string DistrictName { get; set; }
    }
}