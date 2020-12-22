namespace Behlog.Web.ViewModels.Core {
    public abstract class BaseViewModel {
        public bool ModelHasError { get; set; }
        public string ModelMessage { get; set; }
        public string CssClass { get; set; }
        public string CssStyle { get; set; }
    }
}
