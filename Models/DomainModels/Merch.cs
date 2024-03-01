using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.SymbolStore;

namespace MerchShop.Models
{

    public enum MerchType
    {
        Apparel, Electronics, Vehicles
    }
    

    public class Merch
    {

        // Primary Key
        public int MerchID { get; set; } 

        // one to many
        public int VendorID { get; set; }
        public Vendor Vendor { get; set; } = null!; 

        //enum
        public MerchType MerchType { get; set; } 
       
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; } = string.Empty; 

        // rating with range
        [Range(1.0, 5.0)] 
        public float Rating { get; set; } 

        [Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Item Description")]
        public string ItemDescripion { get; set; } = string.Empty;
       
        // many to one
        public ICollection<Inventory> Inventories { get; set; } = new HashSet<Inventory>();
        public ICollection<MerchReview> MerchReviews { get; set; } = new HashSet<MerchReview>();
    }
}
