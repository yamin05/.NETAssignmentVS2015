﻿using System;

namespace WebApplication1.Models
{
    [Serializable]
    public class InterventionType
    {
        public int InterventionTypeId { get; set; }
        public string InterventionTypeName { get; set; }
        public decimal InterventionTypeHours { get; set; }
        public decimal InterventionTypeCost { get; set; }
    }
}