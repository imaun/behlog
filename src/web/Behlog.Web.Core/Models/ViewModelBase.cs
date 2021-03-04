namespace Behlog.Web.Core.Models {

    public abstract class ViewModelBase {
        public bool ShowNotification { get; set; }
        public bool HasError { get; set; }
        public bool Success { get; set; }
        public string ModelMessage { get; set; }
        public string ErrorFieldName { get; set; }
    }

    public abstract class WidgetViewModelBase: ViewModelBase {
        
        public string WidgetTitle { get; set; }

        public string WidgetDescription { get; set; }

        public string WidgetCssIcon { get; set; }

        public string WidgetCssStyle { get; set; }

        public string WidgetBackgroundImageUrl { get; set; }

        public string WidgetCoverImageUrl { get; set; }

        /// <summary>
        /// Specify the action url that will handle the widget form's data
        /// </summary>
        public string WidgetActionUrl { get; set; }
    }
}
