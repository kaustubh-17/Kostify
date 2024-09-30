using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostEstimationSystem.Models
{
    public class UnitModel
    {
        public string trade { get; set; }
        public string company { get; set; }
        public string material { get; set; }
        public string dimension { get; set; }
        public int quantity { get; set; }
        public double unit_cost { get; set; }
    }
}