using WebApplication1.Interfaces;

namespace WebApplication1.Models

{
    public class Users
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string RoleName { get; set; }

        public decimal MaximumHours { get; set; }

        public decimal MaximumCost { get; set; }

        public int District { get; set; }
    }
}