using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Behlog.Resources.Strings;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Behlog.Web.Shop.ViewModels {
    
    public class OrderSingleProductViewModel {

        public OrderSingleProductViewModel() {
            ShippingAddress = new OrderNewShippingAddressViewModel();
            AvailableModels = new List<ProductModelViewModel>();
        }

        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string PriceDisplay => Price.ToString("N0");
        public string Title { get; set; }

        [Display(Name = "Select_ProductModel", ResourceType = typeof(ModelText))]
        public int? SelectedProductModelId { get; set; }

        [Display(Name = "Customer_FirstName", ResourceType = typeof(AppTextDisplay))]
        [MaxLength(300, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string FirstName { get; set; }

        [Display(Name = "Customer_LastName", ResourceType = typeof(AppTextDisplay))]
        [MaxLength(300, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string LastName { get; set; }

        [Display(Name = "NationalCode", ResourceType = typeof(AppTextDisplay))]
        [MaxLength(10, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string NationalCode { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(AppTextDisplay))]
        [MaxLength(11, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string Mobile { get; set; }

        [Display(Name = "Customer_Email", ResourceType = typeof(ModelText))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        [EmailAddress(ErrorMessageResourceName = "Email_Wrong", ErrorMessageResourceType = typeof(ModelError))]
        public string Email { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(AppTextDisplay))]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Wrong_Number")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public int Quantity { get; set; } = 1;

        public IEnumerable<ProductModelViewModel> AvailableModels { get; set; }
        public IEnumerable<SelectListItem> AvailableModelsSource { get; set; }
        public OrderNewShippingAddressViewModel ShippingAddress { get; set; }

    }
}
