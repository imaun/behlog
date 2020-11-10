using System.Collections.Generic;

namespace Behlog.Web.Admin.ViewModels.Core
{
    public class DataTableBaseViewModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<DataTableColumn> columns { get; set; }
        public DataTableSearch search { get; set; }
        public List<DataTableOrder> order { get; set; }

        public DataTableBaseViewModel() {
            columns = new List<DataTableColumn>();
            search = new DataTableSearch();
            order = new List<DataTableOrder>();
        }
    }

    public class DataTableColumn
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public DataTableSearch search { get; set; }

        public DataTableColumn() {
            search = new DataTableSearch();
        }
    }

    public class DataTableSearch
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class DataTableOrder
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
}
