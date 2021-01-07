using System.Collections.Generic;

namespace Behlog.Web.Shop.ViewModels {
    
    public class OrderSingleProductViewModel {

        public OrderSingleProductViewModel() {
            ShippingAddress = new OrderNewShippingAddressViewModel();
            AvailableModels = new List<ProductModelViewModel>();
        }

        public int ProductId { get; set; }
        public string Title { get; set; }
        public int? SelectedProductModelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<ProductModelViewModel> AvailableModels { get; set; }
        public OrderNewShippingAddressViewModel ShippingAddress { get; set; }

    }
}
