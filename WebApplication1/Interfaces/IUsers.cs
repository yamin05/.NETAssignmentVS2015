using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    interface IUsers
    {
        string UserId { get; set; }

        string UserName { get; set; }

         string RoleName { get; set; }

        decimal MaximumHours { get; set; }

        decimal MaximumCost { get; set; }
    }
}
