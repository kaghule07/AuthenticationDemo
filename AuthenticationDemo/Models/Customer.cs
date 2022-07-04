using System.ComponentModel.DataAnnotations;
namespace AuthenticationDemo.Models
{
    public class Customer
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
