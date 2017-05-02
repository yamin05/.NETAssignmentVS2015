using System;

namespace WebApplication1.Models
{
    public class InterventionUpdate
    {
        public int InterventionUpdateId { get; set;}
        public int InterventionId { get; set;}
        public string UserId { get; set;}
        public int Condition { get; set;}
        public DateTime ModifyDate { get; set;}
        public string InterventionComments { get; set; }
    }
}