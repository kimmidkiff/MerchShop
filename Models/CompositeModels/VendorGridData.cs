using System.Text.Json.Serialization;
namespace MerchShop.Models
{
    public class VendorGridData : GridData
    {
        public VendorGridData() => SortField = nameof(Vendor.Name);

        [JsonIgnore]
        public bool IsSortByName => SortField.EqualsNoCase(nameof(Vendor.Name));

        [JsonIgnore]
        public bool IsSortByWebURL => SortField.EqualsNoCase(nameof(Vendor.WebURL));

        
    }
}
