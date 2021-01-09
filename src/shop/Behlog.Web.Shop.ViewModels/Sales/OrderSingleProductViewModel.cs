using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Behlog.Resources.Strings;

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

        [Display(Name = "Customer_FirstName", ResourceType = typeof(AppTextDisplay))]
        [MaxLength(1000, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "MaxLen")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public string Email { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(AppTextDisplay))]
        [Range(minimum:0, maximum: int.MaxValue, ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Wrong_Number")]
        [Required(ErrorMessageResourceType = typeof(ModelError), ErrorMessageResourceName = "Required")]
        public int Quantity { get; set; }

        public IEnumerable<ProductModelViewModel> AvailableModels { get; set; }
        public OrderNewShippingAddressViewModel ShippingAddress { get; set; }

    }
}
