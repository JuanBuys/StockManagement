using StockManagement.API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.API.Models.Service
{
    public class StockItemService : IDataRepository<StockItem, long>
    {
        ApplicationContext context;
        public StockItemService(ApplicationContext c)
        {
            context = c;
        }

        public StockItem Get(long id)
        {
            var StockItem = context.StockItems.FirstOrDefault(b => b.StockItemID == id);
            return StockItem;
        }

        public IEnumerable<StockItem> GetAll()
        {
            var StockItems = context.StockItems.ToList();
            return StockItems;
        }

        public long Add(StockItem stockItem)
        {
            context.StockItems.Add(stockItem);
            long StockItemID = context.SaveChanges();
            return StockItemID;
        }

        public long Delete(long id)
        {
            int StockItemID = 0;
            var StockItem = context.StockItems.FirstOrDefault(b => b.StockItemID == id);
            if (StockItem != null)
            {
                context.StockItems.Remove(StockItem);
                StockItemID = context.SaveChanges();
            }
            return StockItemID;
        }

        public long Update(long id, StockItem item)
        {
            long StockItemID = 0;
            var StockItem = context.StockItems.Find(id);
            if (StockItem != null)
            {
                StockItem.StockItemID = item.StockItemID;
                StockItem.Name = item.Name;
                StockItem.Description = item.Description;
                StockItem.Price = item.Price;
                StockItem.Quantity = item.Quantity;
                StockItem.IsActive = item.IsActive;
                StockItem.LastChangeByUserID = item.LastChangeByUserID;
                StockItem.DateCreated = item.DateCreated;
                StockItem.LastChangeDate = item.LastChangeDate;

                StockItemID = context.SaveChanges();
            }
            return StockItemID;
        }
    }
}