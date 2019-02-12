using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockManagement.API.Models;
using StockManagement.API.Models.Repository;

namespace StockManagement.API.Controllers
{  
    [Route("api/[controller]")]
    public class StockItemController : Controller
    {
        private IDataRepository<StockItem, long> _iRepo;
        public StockItemController(IDataRepository<StockItem, long> repo)
        {
            _iRepo = repo;
        }

        // GET: api/values  
        [HttpGet]
        public IEnumerable<StockItem> Get()
        {
            return _iRepo.GetAll();
        }

        // GET api/values/5  
        [HttpGet("{id}")]
        public StockItem Get(int id)
        {
            return _iRepo.Get(id);
        }

        // POST api/values  
        [HttpPost]
        public void Post([FromBody]StockItem StockItem)
        {
            _iRepo.Add(StockItem);
        }

        // POST api/values  
        [HttpPut]
        public void Put([FromBody]StockItem StockItem)
        {
            _iRepo.Update(StockItem.StockItemID, StockItem);
        }

        // DELETE api/values/5  
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
    
}