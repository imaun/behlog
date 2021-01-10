using System.Threading.Tasks;
using System.Collections.Generic;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Services.Contracts.System;
using Behlog.Web.ViewModels.System;
using Behlog.Web.Shop.ViewModels;
using Behlog.Web.Shop.Data.Extensions;
using Mapster;

namespace Behlog.Web.Shop.Data {

    /// <summary>
    /// Providing the list of all enabled Provinces (<see cref="ProvinceViewModel"/>) 
    /// and their cities (<see cref="CityViewModel"/>)
    /// </summary>
    public class ShippingAddressDataProvider {

        private readonly ICityService _cityService;

        public ShippingAddressDataProvider(ICityService cityService) {
            cityService.CheckArgumentIsNull(nameof(cityService));
            _cityService = cityService;
        }

        public async Task<IEnumerable<ProvinceViewModel>> GetProvincesAsync()
            => (await _cityService.GetProvincesAsync(EntityStatus.Enabled))
                    .Adapt<List<ProvinceViewModel>>();

        public async Task<IEnumerable<CityViewModel>> GetCities(int provinceId)
            => (await _cityService.GetByParentIdAsync(provinceId, EntityStatus.Enabled))
                    .Adapt<List<CityViewModel>>();

        /// <summary>
        /// Get a fresh <see cref="OrderNewShippingAddressViewModel"/> containing related data.
        /// </summary>
        /// <param name="selectedProvinceId">If a province is selected then you must send it's id to mark as selected
        /// in returned SelectList.</param>
        /// <returns>A fresh <see cref="OrderNewShippingAddressViewModel"/> with initial data.</returns>
        public async Task<OrderNewShippingAddressViewModel> GetOrderNewShippingAddressAsync(
            int? selectedProvinceId = null)
            => new OrderNewShippingAddressViewModel {
                ProvinceSelectList = (await GetProvincesAsync())
                    .ToSelectListItems(selectedProvinceId)
            };

    }
}
