using System;

namespace WebApplication1.Models
{
    public class ListInterventions
    {
        public string ClientName { get; set; }
        public string InterventionTypeName { get; set; }
        public decimal InterventionCost { get; set; }
        public decimal InterventionHours { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserName { get; set; }
        public int Status { get; set; }
    }
}