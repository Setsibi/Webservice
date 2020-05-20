using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Units { get; set; }
        public int NumberSoldUnits { get; set; }
        public int RemainingUnits { get; set; }
        public double TotalCostPrice { get; set; }
        public double TotalSellingPrice { get; set; }
        public double Profit { get; set; }
        public Product Product { get; set; }
        public bool Deleted { get; set; }

    }
}
