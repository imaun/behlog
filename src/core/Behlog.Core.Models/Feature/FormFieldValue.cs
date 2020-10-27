using System;

namespace Behlog.Core.Models.Feature {
    public class FormFieldValue {

        public FormFieldValue() { }

        #region Properties
        public long Id { get; set; }
        public long FormFieldId { get; set; }
        public string TextValue { get; set; }
        public int? IntValue { get; set; }
        public decimal? DecValue { get; set; }
        public DateTime? DateValue { get; set; }
        public byte[] FileValue { get; set; }
        public long? FormFieldItemId { get; set; }
        public int? SelectedValueIndex { get; set; }
        public string SelectedValue { get; set; }

        #endregion

        #region Navigations

        public FormField Field { get; set; }
        public FormFieldItem FieldItem { get; set; }

        #endregion

    }
}
