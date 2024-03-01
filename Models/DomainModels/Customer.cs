using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchShop.Models
{
    // constructor requires this data in order to add an entry to Customer table
    public class Customer (string firstName, string lastName, string email, string? userID)
    {
        // PK
        public int CustomerID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = firstName;

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = lastName;

        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; } = email;

        // string? allows nulls
        [Column(TypeName = "nvarchar(450)")]
        public string? UserID { get; set; } = userID;

        // many to one
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<MerchReview> MerchReviews { get; set; } = new HashSet<MerchReview>();
        public ICollection<VendorReview> VendorReviews { get; set; } = new HashSet<VendorReview>();
    }
}
