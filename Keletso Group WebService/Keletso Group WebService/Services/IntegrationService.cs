using Keletso_Group_WebService.Entities;
using Keletso_Group_WebService.Interfaces;
using Keletso_Group_WebService.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace Keletso_Group_WebService.Services
{
    public class IntegrationService : IIntegrationService
    {
        private readonly AppContext context;
        public IntegrationService(AppContext _context)
        {
            context = _context;
        }
        public async Task<List<ChainStores>> GetAllLegos()
        {
            var client = new RestClient("https://datagram-products-v1.p.rapidapi.com/retailers/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "datagram-products-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "68c9c52947msh28db909c6f5adfap154fa2jsn1d184a858db0");
            IRestResponse response = client.Execute(request);

            var stores = new List<ChainStores>();

            if (response.StatusDescription == "OK")
            {
                stores = JsonConvert.DeserializeObject<List<ChainStores>>(response.Content);
            }

            return stores;
        }
        public async Task<List<InventoryModel>> GetLineoCashNCarryInventory()
        {

            var client = new RestClient("https://lineocashncarry.azurewebsites.net/inventory");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var inventory = new List<InventoryModel>();

            if (response.StatusDescription =="OK")
            {
                inventory = JsonConvert.DeserializeObject<List<InventoryModel>>(response.Content);
            }

            return inventory;
        }
    }
}
