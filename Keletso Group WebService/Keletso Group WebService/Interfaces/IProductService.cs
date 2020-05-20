using Keletso_Group_WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProduct(int id);
        Task<int> CreateProduct(ProductModel request);
        Task<int> UpdateProduct(int id, ProductModel request);
        Task DeleteProduct(int id);
      
    }
}
