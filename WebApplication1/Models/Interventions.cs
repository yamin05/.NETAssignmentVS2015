using System;

namespace WebApplication1.Models
{
    public class Interventions
    {
        public int InterventionId { get; set; }
        public string UserId { get; set; }
        public int InterventionTypeId { get; set; }
        public int ClientId { get; set; }
        public decimal InterventionCost { get; set; }
        public decimal InterventionHours { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public string Operator { get; set; }
    }
}