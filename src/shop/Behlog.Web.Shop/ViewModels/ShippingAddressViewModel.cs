namespace Behlog.Web.Shop.ViewModels
{
    /// <summary>
    /// A ViewModel containing ShippingAddress data when visitor (not user) wants to
    /// orde a Product anonymously.
    /// </summary>
    public class OrderNewShippingAddressViewModel {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string ProvinceTitle { get; set; }
        public string CityTitle { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
