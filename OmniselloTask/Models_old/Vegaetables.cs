using System.ComponentModel.DataAnnotations;

namespace OmniselloTask.Models
{
    public class Vegaetables
    {
        [Key]
        public int ID { get; set; }
        public string? NameVegatables { get;set; }
    }
}
