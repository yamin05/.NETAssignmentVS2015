﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EngineersClients
    {
        public int EngineersClientsId { get; set; }
        public string UserId { get; set; }
        public int ClientId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}