using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keletso_Group_WebService.Interfaces;
using Keletso_Group_WebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keletso_Group_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService _inventoryService)
        {
            inventoryService = _inventoryService;
        }
        // GET: api/Inventory
        [HttpGet]
        public async Task<List<InventoryModel>> GetAllInventories()
        {
            return await inventoryService.GetAllInventories();
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<InventoryModel> GetInventory(int id)
        {
            return await inventoryService.GetInventory(id);
        }
                
        // PUT: api/Inventory/5
        [HttpPut("{productId}")]
        public async Task<bool> Put([FromBody] InventoryModel request)
        {
            return await inventoryService.UpdateInventory(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{productId}")]
        public async Task<bool> Delete(int productId)
        {
            return await inventoryService.DeleteInventory(productId);
        }
    }
}
