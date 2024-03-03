using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MerchShop.Models
{
    public class MerchShopUser : IdentityUser
    {
        public int? CustomerID { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; } = null!;
    }
}
