using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Services.Contracts.System;
using Behlog.Core.Models.System;

namespace Behlog.Web.Data.System {

    /// <summary>
    /// Provides <see cref="City"/> data for display in drop-down select lists.
    /// You can get Provinces and cities with diffrent parameters.
    /// </summary>
    public class CityViewModelProvider {

        private readonly ICityService _cityService;

        public CityViewModelProvider(ICityService cityService) {
            cityService.CheckArgumentIsNull(nameof(cityService));
            _cityService = cityService;
        }

        /// <summary>
        /// Get SelectListItems for Provinces or Cities.
        /// </summary>
        /// <param name="parentId">Pass null to get provinces or an integer Id to get cities based on provinceId.</param>
        /// <param name="selectedCityId">Set to check the city as selected in output.</param>
        /// <returns>A list of SelectListItem to Render drop down.</returns>
        public async Task<List<SelectListItem>> GetSelectListAsync(
            int? parentId = null, 
            int? selectedCityId = null) {
            var cities = await _cityService.GetByParentIdAsync(parentId, EntityStatus.Enabled);
            var result = cities.Select(city => new SelectListItem(
                    city.Title,
                    city.Id.ToString(),
                    city.Id == selectedCityId)
                ).ToList();

            return await Task.FromResult(result);
        }

    }
}
