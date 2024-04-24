using OmniselloTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Order_Vege
    {
        //[Key]
        //public int Id { get; set; }
        public int IdVege               { get; set; }
        public Vegetables? Vegetables  { get; set; }
        public int IdOrder              { get; set; }
        public Order? Order              { get; set; }
    }
}
