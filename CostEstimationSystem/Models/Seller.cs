﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostEstimationSystem.Models
{
    public class Seller
    {
        public int seller_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}