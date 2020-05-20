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
    public class IntegrationController : ControllerBase
    {

        private readonly IIntegrationService integrationService;

        public IntegrationController(IIntegrationService _integrationService)
        {
            integrationService = _integrationService;
        }
        // GET: api/AustraliaRetailers
        [HttpGet("AustraliaRetailers")]
        public async Task<List<ChainStores>> GetAllInventories()
        {
            return await integrationService.GetAllLegos();
        }

        // GET: api/LineoCashNCarry_Sales
        [HttpGet("LineoCashNCarry_Inventory")]
        public async Task<List<InventoryModel>> GetSales()
        {
            return await integrationService.GetLineoCashNCarryInventory();
        }      
    }
}
