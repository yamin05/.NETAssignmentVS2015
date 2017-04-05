using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Exceptions;

namespace WebApplication1.For_Test_Purpose
{
    public class UnitTestLogics
    {
        private double allowedHours { get; set; }
        private double allowedCost { get; set; }

        public double allocatedHours { get; private set; }
        public double allocatedCost { get; private set; }

        public UnitTestLogics()
        {
            allowedHours = 100;
            allowedCost = 500;
        }

        public void AllocateHours(double hoursToAllocate)
        {
            if (hoursToAllocate > allowedHours)
            {
                throw new ExcedesAllowedHoursException();
            }
            else
            {
                allocatedHours = hoursToAllocate;
            }
        }

        public void AllocateCost(double costToAllocate)
        {
            if (costToAllocate > allowedCost)
            {
                throw new ExcedesAllowedCostException();
            }
            else
            {
                allocatedCost = costToAllocate;
            }
        }
    }
}