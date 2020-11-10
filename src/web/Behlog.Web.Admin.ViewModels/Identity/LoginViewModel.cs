using System.ComponentModel.DataAnnotations;
using Behlog.Resources.Strings;
using Behlog.Web.Core.Models;

namespace Behlog.Web.Admin.ViewModels.Identity {

    public class LoginViewModel: ViewModelBase {

        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ModelText), Name = "LoginUsername")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ModelText), Name = "LoginPassword")]
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(ModelText), Name = "LoginRememberMe")]
        public bool RememberMe { get; set; }


    }
}
