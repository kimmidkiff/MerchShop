using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchShop.Models
{
    public class Order
    {
        // PK
        public int OrderID { get; set; }

        // one to many
        public int CustomerID { get; set; } 
        public Customer Customer { get; set; } = null!; 

        // automatically generates date upon entry creation
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        [Precision(10,2)]
        public decimal Total { get; set; }

        // many to one
        public ICollection<OrderLines> OrderLine { get; set; } = new HashSet<OrderLines>();
    }
}
