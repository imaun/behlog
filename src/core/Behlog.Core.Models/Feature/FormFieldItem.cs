using Behlog.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Core.Models.Feature {
    public class FormFieldItem: HasMetaData {

        public FormFieldItem() { 
            Values = new HashSet<FormFieldValue>();
        }

        #region Properties
        public long Id { get; set; }
        public long FormFieldId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public int Index { get; set; }
        public int OrderNum { get; set; }

        #endregion

        #region Navigations
        public FormField Field { get; set; }
        public ICollection<FormFieldValue> Values { get; set; }

        #endregion
    }
}
