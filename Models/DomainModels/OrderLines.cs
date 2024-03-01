using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchShop.Models
{
    [PrimaryKey(nameof(OrderID), nameof(InventoryID))]

    public class OrderLines
    {
        public int OrderID { get; set; }
        public Order Order { get; set; } = null!;


        public int InventoryID { get; set; }
        public Inventory Inventory { get; set; } = null!;


        public int Quantity { get; set; }


        [DataType(DataType.Currency)]
        [Precision(6,2)]
        public decimal SubTotal { get; set; }


    }
}
