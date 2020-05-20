using Keletso_Group_WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Interfaces
{
    public interface ISalesService
    {
        Task<List<InventoryModel>> GetAllSales();
        Task<InventoryModel> GetProductSales(int id);
        Task<ProductModel> Buy(SalesModel request);    
      
    }
}
