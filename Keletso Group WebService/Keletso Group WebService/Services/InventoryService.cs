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
    public class InventoryService : IInventoryService
    {
        private readonly AppContext context;
        public InventoryService(AppContext _context)
        {
            context = _context;
        }
        public async Task<List<InventoryModel>> GetAllInventories()
        {
            var inventories = await context.Inventories.Include(x => x.Product).Where(x => !x.Deleted).ToListAsync();
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
        public async Task<InventoryModel> GetInventory(int productId)
        {
            var entity = await context.Inventories.Include(x => x.Product).Where(x => !x.Deleted && x.ProductId == productId).FirstOrDefaultAsync();
            var inventory = new InventoryModel();
            if (entity != null)
            {
                return new InventoryModel
                {
                    ProductId = entity.ProductId,
                    ProductName = entity.Product.Name,
                    Units = entity.Units,
                    NumberSoldUnits = entity.NumberSoldUnits,
                    RemainingUnits = entity.RemainingUnits,
                    TotalCostPrice = entity.TotalCostPrice,
                    TotalSellingPrice = entity.TotalSellingPrice,
                    Profit = entity.Profit
                };
            }
            else
            {
                return inventory;
            }
           
        }
        public async Task<bool> UpdateInventory(InventoryModel request)
        {
            var inventory = await context.Inventories.Where(x => !x.Deleted && x.ProductId == request.ProductId).FirstOrDefaultAsync();

            if (inventory == null)
            {
                var entity = new Inventory
                {
                    ProductId = request.ProductId,
                    Units = request.Units,
                    NumberSoldUnits = request.NumberSoldUnits,
                    RemainingUnits = request.RemainingUnits,
                    TotalCostPrice = request.TotalCostPrice,
                    TotalSellingPrice = request.TotalSellingPrice                  
                };

                await context.AddAsync(entity);
            }
            else
            {
                inventory.Units += request.Units;
                inventory.RemainingUnits += request.RemainingUnits;
                inventory.TotalCostPrice = request.TotalCostPrice;
                inventory.TotalSellingPrice = request.TotalSellingPrice;       
            }

            await context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteInventory(int productId)
        {
            var inventory = await context.Inventories.Where(x => x.ProductId == productId).FirstOrDefaultAsync();

            if (inventory == null)
            {
                throw new ArgumentNullException("Product does not exist");
            }

            inventory.Deleted = true;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Sales(InventoryModel request)
        {
            var inventory = await context.Inventories.Where(x => !x.Deleted && x.ProductId == request.ProductId).FirstOrDefaultAsync();

            if (inventory == null)
            {
                throw new ArgumentNullException("Product does not exist");
            }

            inventory.NumberSoldUnits++;
            inventory.RemainingUnits--;   
            inventory.Profit = inventory.TotalSellingPrice - request.TotalCostPrice;

            await context.SaveChangesAsync();

            return true;
        }
    }
}
