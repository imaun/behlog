namespace Behlog.Services.Dto.Core
{
    public class IndexParams<T> where T: class
    {
        public IndexParams(int pageNum, int pageSize) {
            PageNumber = pageNum;
            PageSize = pageSize;
        }

        public IndexParams(
            int pageNum = 1, 
            int pageSize = 10, 
            T filter = null) {

            PageNumber = pageNum;
            PageSize = pageSize;
            Filter = filter;
        }

        public string LangKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchValue { get; set; }
        public string SearchKey { get; set; }
        public T Filter { get; set; }

        public int Skip => (PageNumber-1) * PageSize;
        public int Take => PageSize;
    }
}
