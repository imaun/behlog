using System.Collections.Generic;
using Behlog.Core.Models.Base;
using Behlog.Core.Models.Enum;

namespace Behlog.Core.Models.Feature {
    public class FormField: HasMetaData {

        public FormField() {
            Items = new HashSet<FormFieldItem>();
            Values = new HashSet<FormFieldValue>();
        }

        #region Properties
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int FormId { get; set; }
        public string Description { get; set; }
        public FormFieldType FieldType { get; set; }
        public bool Required { get; set; }
        public int OrderNum { get; set; }

        #endregion

        #region Navigations
        public Form Form { get; set; }
        public ICollection<FormFieldItem> Items { get; set; }
        public ICollection<FormFieldValue> Values { get; set; }

        #endregion
    }
}
