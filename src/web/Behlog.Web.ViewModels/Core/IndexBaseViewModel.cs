using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.ViewModels.Core
{
    public abstract class IndexBaseViewModel: BaseViewModel
    {
        public int PageSize { get; set; }
        public int PageCount => TotalCount / PageSize;
        public int CurrentPageNumber { get; set; }
        public int TotalCount { get; set; }
    }
}
