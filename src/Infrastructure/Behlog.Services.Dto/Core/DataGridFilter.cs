namespace Behlog.Services.Dto.Core {
    public abstract class DataGridFilter {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderKey { get; set; }
        public bool OrderDesc { get; set; }
        public int StartIndex => PageIndex * PageSize;
    }
}
