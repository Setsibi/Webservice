using Keletso_Group_WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Interfaces
{
    public interface IInventoryService
    {
        Task<List<InventoryModel>> GetAllInventories();
        Task<InventoryModel> GetInventory(int id);
        Task<bool> Sales(InventoryModel request);
        Task<bool> DeleteInventory(int id);
        Task<bool> UpdateInventory(InventoryModel request);
    }
}
