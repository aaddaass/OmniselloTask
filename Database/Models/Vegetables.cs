using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace OmniselloTask.Models
{
    public class Vegetables
    {
        [Key]
        public int      ID                  { get; set; }
        public string?  NameVegetables      { get;set; }
        public decimal? VegetablesPrice    { get; set; }
        public string?  VegetablesUnit      { get; set; }
        public IList<Order_Vege>? VegeOrder { get; set;  }

    }
}
