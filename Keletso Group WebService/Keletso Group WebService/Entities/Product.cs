using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public double SellingPrice { get; set; }
        public double CostPrice { get; set; }
        public string Make { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public bool Deleted { get; set; }
    }
}
