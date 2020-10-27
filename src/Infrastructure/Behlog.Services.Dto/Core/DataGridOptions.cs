using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Services.Dto.Core
{
    public class DataGridOptions
    {
        public string FilterText { get; set; }
        public string FilterFiledName { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public bool OrderAsc { get; set; } = true;
        public string OrderByFieldName { get; set; }
    }
}
