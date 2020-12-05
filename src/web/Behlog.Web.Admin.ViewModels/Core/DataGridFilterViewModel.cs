namespace Behlog.Web.Admin.ViewModels.Core
{
    public abstract class DataGridFilterViewModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public string OrderKey { get; set; }
        public bool OrderDesc { get; set; }
        public int StartIndex => PageIndex * PageSize;
        public int CurrentPage => PageIndex + 1;
        public int NextPage => CurrentPage + 1;
        public int PreviousPage => CurrentPage - 1;
        
    }
}
