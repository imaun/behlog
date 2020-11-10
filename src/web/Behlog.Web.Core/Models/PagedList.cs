using System.Collections.Generic;

namespace Behlog.Web.Core.Models
{
    public class PagedList<T> where T: class
    {
        public PagedList() {
            Items = new List<T>();
        }

        public ICollection<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int ItemsCount => Items?.Count ?? 0;
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
