﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchShop.Models
{
 
    public enum WarehouseNumber
    {
        One, Two, Three 
    }
    public class Warehouse
    {
        // PK
        public int WarehouseID { get; set; } 

        // enum
        public WarehouseNumber WarehouseNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        [Display(Name = "Shelf Number")]
        public string ShelfNumber { get; set; } = string.Empty;

        //Navigation to Inventory table 
        public ICollection<Inventory> OrderLine { get; set; } = new HashSet<Inventory>();

    }
}
