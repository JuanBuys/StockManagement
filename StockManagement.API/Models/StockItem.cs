using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.API.Models
{
    public class StockItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime LastChangeDate { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("User")]
        public int LastChangeByUserID { get; set; }
        public User User { get; set; }
        
    }


}
