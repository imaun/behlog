namespace Behlog.Web.Core.Models {
    public abstract class ViewModelBase {
        public bool ShowNotification { get; set; }
        public bool HasError { get; set; }
        public bool Success { get; set; }
        public string ModelMessage { get; set; }
        public string ErrorFieldName { get; set; }
    }
}
