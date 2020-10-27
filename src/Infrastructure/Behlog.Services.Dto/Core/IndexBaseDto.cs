namespace Behlog.Services.Dto.Core
{
    public abstract class IndexBaseDto
    {
        public int PageSize { get; set; }
        public int PageCount => TotalCount / PageSize;
        public int CurrentPageNumber { get; set; }
        public int TotalCount { get; set; }
    }
}
