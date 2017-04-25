namespace WebApplication1.Models
{
    public class Users
    {
        public string UserId { get; set; }
        
        public decimal MaximumHours { get; set; }

        public decimal MaximumCost { get; set; }

        public int District { get; set; }
    }
}