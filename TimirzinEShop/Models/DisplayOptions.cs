namespace TimirzinEShop.Models
{
    public enum SortBy
    {
        None,
        Price,
        ProductName
    }
    public class DisplayOptions
    {
        public SortBy SortBy { get; set; }
        public bool IsDesc { get; set; }
        public string SearchValue { get; set; }
        public FilterType CommonFilterType { get; set; }
        public string CommonFilterValue { get; set; }
        public DisplayOptions()
        {
            SortBy = SortBy.None;
            IsDesc = false;
            SearchValue = null;
        }
    }
}