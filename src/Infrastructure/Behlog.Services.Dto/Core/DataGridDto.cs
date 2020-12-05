using System.Collections.Generic;

namespace Behlog.Services.Dto.Core
{
    public class DataGridDto<T> where T: class 
    {
        public DataGridDto() {
            Items = new List<T>();
        }

        public DataGridDto(IList<T> items) {
            Items = items;
        }

        public DataGridDto(IList<T> items, int totalCount) {
            Items = items;
            TotalCount = totalCount;
        }

        public IList<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PageCount => (TotalCount / PageSize)+1;
        
    }
}