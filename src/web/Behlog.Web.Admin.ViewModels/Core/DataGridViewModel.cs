using System.Collections.Generic;

namespace Behlog.Web.Admin.ViewModels.Core
{
    public class DataGridViewModel<T> where T: class
    {
        public DataGridViewModel() {
            Items = new List<T>();
        }

        public IList<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage => PageIndex + 1;
        public int NextPage => CurrentPage + 1;
        public int PreviousPage => CurrentPage - 1;
        public bool CanGoNextPage => NextPage <= PageCount;
        public bool CanGoPreviousPage => PreviousPage > 0 && PreviousPage <= PageCount;
        public bool IsNotEmpty => Items != null && Items.Count > 0;
        public bool HasFilter { get; set; }
    }
}
