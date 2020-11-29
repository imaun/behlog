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
        public int PageCount => TotalCount / PageSize;
    }
}
