using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Models
{
    public class ChainStores
    {
       public ChainStores()
        {
            Stores = new List<Store>();
        }

        public List<Store> Stores { get; set; }
    }

    public class Store
    {
        public string Store_Id { get; set; }
        public string Address { get; set; }
        public string Store_Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Opened { get; set; }
        public string Closed { get; set; }     
    }
 

}
