using System.ComponentModel.DataAnnotations;
using Behlog.Resources.Strings;
using Behlog.Web.Core.Models;

namespace Behlog.Web.ViewModels.Feature {

    public class CreateContactViewModel: WidgetViewModelBase {

        [Display(ResourceType = typeof(ModelText), Name = "Contact_Name")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Contact_Name_Required")]
        [MaxLength(100, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Contact_Title")]
        [MaxLength(300, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Title { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Contact_Email")]
        [EmailAddress(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Email_Wrong")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Contact_Email_Required")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Contact_Phone")]
        [Phone(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Contact_Phone_Wrong")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Contact_Phone_Required")]
        [MaxLength(20, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Contact_Phone_Wrong")]
        public string Phone { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "Contact_Message")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Contact_Message_Required")]
        [MaxLength(3000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Message { get; set; }

        public WebsiteContactInfoViewModel ContactInfo { get; set; }
        public WebsiteSocialNetworksViewModel SocialNetworks { get; set; }
    }

    public class WebsiteContactInfoViewModel {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phones { get; set; }
        public string[] PhoneList => Phones.Split(",");
        public string Email { get; set; }
        public string Copyright { get; set; }
        public string GoogleMapCode { get; set; }
    }

    public class WebsiteSocialNetworksViewModel
    {
        public string Telegram { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Whatsapp { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string YouTube { get; set; }
    }

    public class ContactInfoWidgetViewModel {
        public ContactInfoWidgetViewModel() {
            SocialNetworks = new WebsiteSocialNetworksViewModel();
        }

        public string Address { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public WebsiteSocialNetworksViewModel SocialNetworks { get; set; }
    }
}
