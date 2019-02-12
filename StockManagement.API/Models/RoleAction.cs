using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.API.Models
{
    public class RoleAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleActionID { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Action")]
        public int ActionID { get; set; }
        public Action Action { get; set; }
    }
}
