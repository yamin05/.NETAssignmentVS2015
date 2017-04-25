using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Interventions
    {
        public int InterventionId { get; set; }
        public string UserId { get; set; }
        public int InterventionTypeId { get; set; }
        public int ClientId { get; set; }
        public float InterventionCost { get; set; }
        public float InterventionHour { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public int Operater { get; set; }
    }
}