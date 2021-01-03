using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Enum;
using Behlog.Services.Dto.System;
using Behlog.Services.Contracts.System;
using Behlog.Core.Contracts.Repository.System;
using Mapster;

namespace Behlog.Services.System {

    public class CityService: ICityService {

        private readonly ICityRepository _cityRepository;

        public CityService(
            ICityRepository cityRepository) {

            cityRepository.CheckArgumentIsNull(nameof(cityRepository));
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<CityResultDto>> GetByParentIdAsync(
            int? parentId, 
            EntityStatus? status = EntityStatus.Enabled) {
            var result = (await _cityRepository
                .GetByParentIdAsync(parentId, status))
                .Adapt<List<CityResultDto>>();

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<CityResultDto>> GetProvincesAsync(
            EntityStatus? status = EntityStatus.Enabled) => await GetByParentIdAsync(null, status);
        
    }
}
