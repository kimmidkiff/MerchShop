
using System.Text.Json.Serialization;
namespace MerchShop.Models
{
    public class MerchReviewGridData : GridData
    {
        public MerchReviewGridData() => SortField = nameof(Merch.ItemName);

        [JsonIgnore]
        public bool IsSortByName => SortField.EqualsNoCase(nameof(Merch.ItemName));

        [JsonIgnore]
        public bool IsSortByReviewScore => SortField.EqualsNoCase(nameof(MerchReview.ReviewScore.ToString));
    }
}
