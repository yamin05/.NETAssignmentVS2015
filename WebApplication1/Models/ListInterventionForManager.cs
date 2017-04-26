using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ListInterventionForManager
    {
        public int District { get; set; }
        public int ClientDistrict { get; set; }
        public string ClientName { get; set; }
        public string InterventionTypeName { get; set; }
        public decimal InterventionCost { get; set; }
        public decimal InterventionHours { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
    }
}