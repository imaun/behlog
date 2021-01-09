using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Behlog.Web.ViewModels.System;
using Behlog.Resources.Strings;

namespace Behlog.Web.Shop.ViewModels
{
    /// <summary>
    /// A ViewModel containing ShippingAddress data when visitor (not user) wants to
    /// orde a Product anonymously.
    /// </summary>
    public class OrderNewShippingAddressViewModel {

        public OrderNewShippingAddressViewModel() {
            ProvinceSelectList = new List<SelectListItem>();
        }

        [Display(Name = "Province", ResourceType = typeof(AppTextDisplay))]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public int ProvinceId { get; set; }

        [Display(Name = "City", ResourceType = typeof(AppTextDisplay))]
        public int CityId { get; set; }

        public string ProvinceTitle { get; set; }
        public string CityTitle { get; set; }
        public string Street { get; set; }

        [Display(Name = "Customer_Address", ResourceType = typeof(AppTextDisplay))]
        [MaxLength(300, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string Address { get; set; }

        [Display(Name = "PostalCode", ResourceType = typeof(AppTextDisplay))]
        [MaxLength(300, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string PostalCode { get; set; }

        public IEnumerable<SelectListItem> ProvinceSelectList { get; set; }
        
    }
}
