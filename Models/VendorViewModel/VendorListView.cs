namespace MerchShop.Models
{
    public class VendorListView
    {
        public IEnumerable<Vendor> Vendor { get; set; } = new HashSet<Vendor>();
        public VendorGridData CurrentRoute { get; set; } = new VendorGridData();
        public int TotalPages { get; set; }
    }
}
