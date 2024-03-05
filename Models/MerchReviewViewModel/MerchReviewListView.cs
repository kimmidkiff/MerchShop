namespace MerchShop.Models
{
    public class MerchReviewListView
    {
        public IEnumerable<MerchReview> MerchReview { get; set; } = new HashSet<MerchReview>();
        public MerchReviewGridData CurrentRoute { get; set; } = new MerchReviewGridData();
        public int TotalPages { get; set; }
    }
}

