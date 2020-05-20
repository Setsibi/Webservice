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
    public class SalesController : ControllerBase
    {
        private readonly ISalesService salesService;

        public SalesController(ISalesService _salesService)
        {
            salesService = _salesService;
        }
        // GET: api/Finance
        [HttpGet]
        public async Task<List<InventoryModel>> GetAllSales()
        {
            return await salesService.GetAllSales();
        }

        // GET: api/Finance/5
        [HttpGet("{id}")]
        public async Task<InventoryModel> GetProductSale(int id)
        {
            return await salesService.GetProductSales(id);
        }

        // POST: api/Finance
        [HttpPost]
        public async Task<ProductModel> Buy([FromBody] SalesModel request)
        {
           return await salesService.Buy(request);
        }

        // PUT: api/Finance/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
