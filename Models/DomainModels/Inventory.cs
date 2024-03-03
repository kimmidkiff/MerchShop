using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchShop.Models
{
    public class Inventory
    {
        // PK
        public int InventoryID { get; set; }

        // one to many
        public int MerchID { get; set; } 
        public Merch Merch { get; set; } = null!; 

        public int WarehouseID { get; set; } 
        public Warehouse Warehouse { get; set; } = null!; 

        [Column(TypeName = "integer")]
        public int Quantity { get; set; }

        // DateTime object stores PurchaseDate as a date
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        // Currency stores the PurchasePrice as a $ amount
        [DataType(DataType.Currency)]
        [Precision(6, 2)] 
        public decimal PurchasePrice { get; set; }

        [DataType(DataType.Currency)]
        [Precision(6, 2)] 
        public decimal SalePrice { get; set; } 

        // many to one
        public ICollection<OrderLines> OrderLine { get; set; } = new HashSet<OrderLines>();
    }

}
