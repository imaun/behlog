using System.ComponentModel.DataAnnotations;
using Behlog.Resources.Strings;

namespace Behlog.Web.ViewModels.Feature
{
    public class SubscriberViewModel
    {
        [Display(ResourceType = typeof(ModelText), Name = "Subscriber_Email")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Subscriber_Email_Required")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [EmailAddress(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Email_Wrong")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Subscriber_Name")]
        [MaxLength(300, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Name { get; set; }

        public bool Success { get; set; }

        public bool HasError { get; set; }

        public string Message { get; set; }
    }
}
