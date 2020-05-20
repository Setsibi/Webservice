using Keletso_Group_WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Interfaces
{
    public interface IIntegrationService
    {
        Task<List<ChainStores>> GetAllStores();
        Task<List<InventoryModel>> GetLineoCashNCarryInventory();       
    }
}
