using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockManagement.WEB.Helpers;
using StockManagement.WEB.Models;

namespace StockManagement.WEB.Controllers
{
    public class StockItemController : Controller
    {
        StockManagementAPI _stockItemAPI = new StockManagementAPI();

        public async Task<IActionResult> Index()
        {
            List<StockItemViewModel> dto = new List<StockItemViewModel>();

            HttpClient client = _stockItemAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/stockitem");

            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api 
                dto = JsonConvert.DeserializeObject<List<StockItemViewModel>>(result);

            }
          
            return View(dto);
        }

        // GET: StockItem/Create  
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockItem/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StockItemID,Name,Description,Price,Quantity,LastChangeDate,DateCreated,IsActive,LastChangeByUserID")] StockItemViewModel stockItem)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _stockItemAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(stockItem), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/stockitem", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(stockItem);
        }

        // GET: StockItem/Edit/1  
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<StockItemViewModel> dto = new List<StockItemViewModel>();
            HttpClient client = _stockItemAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/stockitem");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<StockItemViewModel>>(result);
            }

            var stockItem = dto.SingleOrDefault(m => m.StockItemID == id);
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // POST: StockItem/Edit/1  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("StockItemID,Name,Description,Price,Quantity,LastChangeDate,DateCreated,IsActive,LastChangeByUserID")] StockItemViewModel stockItem)
        {
            if (id != stockItem.StockItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _stockItemAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(stockItem), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("api/stockitem", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(stockItem);
        }

        // GET: StockItem/Delete/1  
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<StockItemViewModel> dto = new List<StockItemViewModel>();
            HttpClient client = _stockItemAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/stockitem");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<StockItemViewModel>>(result);
            }

            var stockItem = dto.SingleOrDefault(m => m.StockItemID == id);
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // POST: StockItem/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            HttpClient client = _stockItemAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync($"api/stockitem/{id}").Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}