using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Models
{
    public class InventoryModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Units { get; set; }
        public int NumberSoldUnits { get; set; }
        public int RemainingUnits { get; set; }
        public double TotalCostPrice { get; set; }
        public double TotalSellingPrice { get; set; }
        public double Profit { get; set; }
        public bool Deleted { get; set; }
    }
}
