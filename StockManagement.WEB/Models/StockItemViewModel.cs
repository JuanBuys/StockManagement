﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.WEB.Models
{
    public class StockItemViewModel
    {
        public int StockItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime LastChangeDate { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public int LastChangeByUserID { get; set; }
       
    }
}
