namespace TimirzinEShop.Models
{
    public class DisplayOptions
    {
        public SortBy SortBy { get; set; }
        public bool IsDesc { get; set; }
        public string SearchValue { get; set; }
        public FilterType CommonFilterType { get; set; }
        public string CommonFilterValue { get; set; }
        public double CommonFilterValueMin { get; set; }
        public double CommonFilterValueMax { get; set; }
        public string CategoryFilterType { get; set; }
        public string CategoryFilterValueSelect { get; set; }
        public double CategoryFilterValueMin { get; set; }
        public double CategoryFilterValueMax { get; set; }

        public DisplayOptions()
        {
            SortBy = SortBy.None;
            IsDesc = false;
            SearchValue = null;
            CommonFilterType = FilterType.None;
            CommonFilterValue = null;
            CategoryFilterValueSelect = null;
        }
    }
}
public enum SortBy
{
    None,
    Price,
    ProductName
}