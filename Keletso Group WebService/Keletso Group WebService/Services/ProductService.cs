using Keletso_Group_WebService.Entities;
using Keletso_Group_WebService.Interfaces;
using Keletso_Group_WebService.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Services
{
    public class ProductService : IProductService
    {
        private readonly AppContext context;
        private readonly IInventoryService inventoryService;

        public ProductService(AppContext _context, IInventoryService _inventoryService)
        {
            context = _context;
            inventoryService = _inventoryService;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            var products = await context.Products.ToListAsync();
            var productList = new List<ProductModel>();

            foreach (var product in products)
            {
                productList.Add(new ProductModel
                {
                    Name = product.Name,
                    Barcode = product.Barcode,
                    SellingPrice = product.SellingPrice,
                    CostPrice = product.CostPrice,
                    Make = product.Make
                });
            }

            return productList;
        }
        public async Task<ProductModel> GetProduct(int id)
        {
            var product = await context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            return new ProductModel
            {
                Name = product.Name,
                Barcode = product.Barcode,
                SellingPrice = product.SellingPrice,
                CostPrice = product.CostPrice,
                Make = product.Make
            };

        }
        public async Task<int> CreateProduct(ProductModel request)
        {
            var entity = new Product
            {
                Name = request.Name,
                Barcode = request.Barcode,
                SellingPrice = request.SellingPrice,
                CostPrice = request.CostPrice,
                Make = request.Make
            };


            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            InventoryModel inventory = await inventoryService.GetInventory(entity.Id);

            if (inventory.ProductId > 0)
            {
                inventory.Units++;
                inventory.RemainingUnits++;
            }
            else
            {
                inventory.Units = +1;
                inventory.RemainingUnits = +1;
                inventory.TotalCostPrice = entity.CostPrice;
                inventory.TotalSellingPrice = entity.SellingPrice;
                inventory.ProductId = entity.Id;
            }

            await inventoryService.UpdateInventory(inventory);

            return entity.Id;
        }
        public async Task<int> UpdateProduct(int id, ProductModel request)
        {
            var product = await context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException("Employee does not exist");
            }

            product.Name = request.Name;
            product.Barcode = request.Barcode;
            product.SellingPrice = request.SellingPrice;
            product.CostPrice = request.CostPrice;
            product.Make = request.Make;

            InventoryModel inventory = await inventoryService.GetInventory(product.Id);

            inventory.TotalCostPrice = product.CostPrice;
            inventory.TotalSellingPrice = product.SellingPrice;

            await context.SaveChangesAsync();
                  

            return product.Id;
        }
        public async Task DeleteProduct(int id)
        {
            var product = await context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ArgumentNullException("Employee does not exist");
            }

            product.Deleted = true;

            InventoryModel inventory = await inventoryService.GetInventory(product.Id);

            inventory.Deleted = product.Deleted;


            await context.SaveChangesAsync();

          
        }

    }
}
