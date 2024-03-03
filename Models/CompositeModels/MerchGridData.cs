using System.Text.Json.Serialization;
namespace MerchShop.Models
{
    public class MerchGridData : GridData
    {
        public MerchGridData() => SortField = nameof(Merch.ItemName);

        [JsonIgnore]
        public bool IsSortByName => SortField.EqualsNoCase(nameof(Merch.ItemName));

        [JsonIgnore]
        public bool IsSortByVendor => SortField.EqualsNoCase(nameof(Vendor.Name));


    }
}
