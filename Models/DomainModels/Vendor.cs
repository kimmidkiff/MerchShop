using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchShop.Models
{
    public class Vendor
    {
        // PK
        public int VendorID { get; set; } 

        [Column(TypeName = "nvarchar(100)")] 
        public string Name { get; set; } = string.Empty; 

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Web URL")]
        public string WebURL { get; set; } = string.Empty; 

        // float rating with a range constraint
        [Range(1.0, 5.0)]
        [Display(Name = "Overall Rating")]
        public float OverallRating { get; set; } 

        // many to one relationships
        public ICollection<Merch> Merches { get; set; } = new HashSet<Merch>();
        public ICollection<VendorReview> VendorReviews { get; set; } = new HashSet<VendorReview>();
    }
}