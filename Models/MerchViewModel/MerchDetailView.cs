using System.Collections;
using System.Collections.Generic;

namespace MerchShop.Models
{
    public class MerchDetailView
    {
        public Merch Merch { get; set; } = new Merch();
        public IEnumerable<Vendor> Vendors { get; set; } = [];

    }
}
