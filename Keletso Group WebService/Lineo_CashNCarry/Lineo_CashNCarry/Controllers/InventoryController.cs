using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lineo_CashNCarry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : Controller
    {   

        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        // GET: Inventory
        [HttpGet]
        public Task<List<InventoryModel>> GetAllInventories()
        {
            return Get();
        }

        private async Task<List<InventoryModel>> Get()
        {
            var inventoryList = new List<InventoryModel>();

            var inventory1 = new InventoryModel();
            var inventory2 = new InventoryModel();
            var inventory3 = new InventoryModel();
            //Iwisa
            inventory1.ProductId = 1;
            inventory1.ProductName = "Iwisa Maize Meal";
            inventory1.Units = 200;
            inventory1.NumberSoldUnits = 50;
            inventory1.RemainingUnits = 150;
            inventory1.TotalCostPrice = 30;
            inventory1.TotalSellingPrice = 20;
            inventory1.Profit = 10;
            //Selati Brown Sugar
            inventory2.ProductId = 2;
            inventory2.ProductName = "Selati Brown Sugar";
            inventory2.Units = 500;
            inventory2.NumberSoldUnits = 450;
            inventory2.RemainingUnits = 50;
            inventory2.TotalCostPrice = 50;
            inventory2.TotalSellingPrice = 65;
            inventory2.Profit = 15;
            //Golden Cloud Cake Flour
            inventory3.ProductId = 3;
            inventory3.ProductName = "Golden Cloud Cake Flour";
            inventory3.Units = 750;
            inventory3.NumberSoldUnits = 400;
            inventory3.RemainingUnits = 350;
            inventory3.TotalCostPrice = 80;
            inventory3.TotalSellingPrice = 95;
            inventory3.Profit = 15;


            inventoryList.Add(inventory1);
            inventoryList.Add(inventory2);
            inventoryList.Add(inventory3);

            return inventoryList;
        }



    }
}