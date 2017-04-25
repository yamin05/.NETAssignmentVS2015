using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class InterventionType
    {
        public int InterventionId { get; set; }
        public string InterventionTypeName { get; set; }
        public float InterventionTypeHours { get; set; }
        public float InterventionTypeCost { get; set; }
    }
}