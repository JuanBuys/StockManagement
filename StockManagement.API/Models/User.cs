using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.API.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime LastChangeDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public Role Role { get; set; }

        public ICollection<StockItem> StockItems { get; set; }
    }
}
