using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.API.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Action> Actions { get; set; }
    }

    public enum Roles
    {
        Admin = 1,
        User = 2,
        StockController = 3,
        Guest = 4
    }
}
