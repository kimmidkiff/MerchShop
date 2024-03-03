namespace MerchShop.Models
{
    public class MerchListView
    {
        public IEnumerable<Merch> Merch { get; set; } = new HashSet<Merch>();
        public MerchGridData CurrentRoute { get; set; } = new MerchGridData();
        public int TotalPages { get; set; }
    }
}
