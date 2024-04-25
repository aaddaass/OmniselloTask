using OmniselloTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Order
    {
        [Key]
        public int      Id          { get; set; }
        public DateTime OrderDate   { get; set; }
        public decimal?  OrderAmount { get; set; }
        public string?  ID_User     { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public IList<Order_Vege>? Order_Veges    { get; set; }
    }
}
