using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Models
{
    public class SalesModel
    {
        public int? ProductId { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }     
    }
}
