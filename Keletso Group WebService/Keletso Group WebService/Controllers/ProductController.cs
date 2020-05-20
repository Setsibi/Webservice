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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IEnumerable<ProductModel>> Get()
        {
            return await productService.GetAllProducts();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ProductModel> Get(int id)
        {
            return await productService.GetProduct(id);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<int> Post([FromBody] ProductModel request)
        {
          return await productService.CreateProduct(request);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] ProductModel request)
        {
            return await productService.UpdateProduct(id, request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await productService.DeleteProduct(id);
        }
    }
}
