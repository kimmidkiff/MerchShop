using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchShop.Models
{
    // Composite key for keyless table
    [PrimaryKey(nameof(VendorID), nameof(CustomerID))]

    public class VendorReview
    {
        // FK - one to many
        public int VendorID { get; set; }
        public Vendor Vendor { get; set; } = null!;

        // FK - one to many
        public int CustomerID { get; set; }
        public Customer Customer { get; set; } = null!;
        
        public DateTime Date { get; set; }

        [Range(1, 5)]
        public int ReviewScore { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string ReviewText { get; set; } = string.Empty;

    }
}
