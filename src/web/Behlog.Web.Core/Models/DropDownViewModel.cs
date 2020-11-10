using System.Collections.Generic;

namespace Behlog.Web.Core.Models
{
    public class DropDownViewModel
    {
        public DropDownViewModel() {
            Items = new List<DropDownItemViewModel>();
        }

        public ICollection<DropDownItemViewModel> Items { get; set; }

        public void Add(string title, object value) {
            Add(new DropDownItemViewModel {
                Title = title,
                Value = value
            });
        }

        public void Add(DropDownItemViewModel item) {
            Items.Add(item);
        }
    }

    public class DropDownItemViewModel {

        public string Title { get; set; }
        public object Value { get; set; }
    }

    public class SelectItemViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
