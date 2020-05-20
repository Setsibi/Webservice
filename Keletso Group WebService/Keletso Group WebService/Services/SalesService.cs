using Keletso_Group_WebService.Entities;
using Keletso_Group_WebService.Interfaces;
using Keletso_Group_WebService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keletso_Group_WebService.Services
{
    public class SalesService : ISalesService
    {
        private readonly AppContext context;

        public SalesService(AppContext _context)
        {
            context = _context;
        }

        public async Task<List<InventoryModel>> GetAllSales()
        {
            var inventories = await context.Inventories.Where(x => !x.Deleted).Include(x => x.Product).ToListAsync();
            var inventoryList = new List<InventoryModel>();

            foreach (var inventory in inventories)
            {
                inventoryList.Add(new InventoryModel
                {
                    ProductId = inventory.ProductId,
                    ProductName = inventory.Product.Name,
                    Units = inventory.Units,
                    NumberSoldUnits = inventory.NumberSoldUnits,
                    RemainingUnits = inventory.RemainingUnits,
                    TotalCostPrice = inventory.TotalCostPrice,
                    TotalSellingPrice = inventory.TotalSellingPrice,
                    Profit = inventory.Profit
                });
            }

            return inventoryList;
        }
        public async Task<InventoryModel> GetProductSales(int id)
        {
            var inventory = await context.Inventories.Where(x => !x.Deleted).Include(x => x.Product).FirstOrDefaultAsync();

            return new InventoryModel
            {
                ProductId = inventory.ProductId,
                ProductName = inventory.Product.Name,
                Units = inventory.Units,
                NumberSoldUnits = inventory.NumberSoldUnits,
                RemainingUnits = inventory.RemainingUnits,
                TotalCostPrice = inventory.TotalCostPrice,
                TotalSellingPrice = inventory.TotalSellingPrice,
                Profit = inventory.Profit
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

            return entity.Id;
        }
        public async Task<ProductModel> Buy(SalesModel request)
        {
            var product = new Product();

            if (request.ProductId > 0)
            {
                product = await context.Products.Where(x => x.Id == request.ProductId).FirstOrDefaultAsync();

            }

            if (request.Barcode != null)
            {
                product = await context.Products.Where(x => x.Barcode == request.Barcode).FirstOrDefaultAsync();
            }


            if (product == null)
            {
                throw new ArgumentNullException("Product does not exist");
            }

            var inventory = await context.Inventories.Where(x => x.ProductId == product.Id).FirstOrDefaultAsync();
            inventory.Units--;
            inventory.Profit += product.SellingPrice - product.CostPrice;

            await context.SaveChangesAsync();

            return new ProductModel
            {
                Name = product.Name,
                Barcode = product.Barcode,
                SellingPrice = product.SellingPrice,             
                Make = product.Make
            };
                    


        }
      
    }
}
