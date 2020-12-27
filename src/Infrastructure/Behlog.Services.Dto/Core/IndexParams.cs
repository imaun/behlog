namespace Behlog.Services.Dto.Core {
    public class IndexParams {
        public IndexParams(int pageNum = 1, int pageSize = 10) {
            PageNumber = pageNum;
            PageSize = pageSize;
        }

        public bool HasPaging { get; set; } = true;
        public string LangKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchValue { get; set; }
        public string SearchKey { get; set; }
        public int Skip => (PageNumber - 1) * PageSize;
        public int Take => PageSize;
        public string OrderBy { get; set; }
        public bool OrderDesc { get; set; }
    }

    public class IndexParams<T>: IndexParams where T: class
    {
        public IndexParams(int pageNum, int pageSize) 
            : base(pageNum, pageSize) { }

        public IndexParams(int pageNum = 1, int pageSize = 10, T filter = null)
            : base(pageNum, pageSize) {
            Filter = filter;
        }

        public T Filter { get; set; }
    }
}
