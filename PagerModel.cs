namespace ApiFactory.ReturnAlways
{
    public class PagerModel
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int TotalPageCount { get; set; }
        public int CurrentPageNumber { get; set; }
        public int CurrentRowCount { get; set; }
    }
}
