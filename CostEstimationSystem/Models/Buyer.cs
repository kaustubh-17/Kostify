﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostEstimationSystem.Models
{
    public class Buyer
    {
        public int buyer_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}