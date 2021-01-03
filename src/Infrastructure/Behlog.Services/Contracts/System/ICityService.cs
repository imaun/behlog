using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Services.Dto.System;
using System.Text;
using Behlog.Core.Models.Enum;

namespace Behlog.Services.Contracts.System {

    public interface ICityService {
        Task<IEnumerable<CityResultDto>> GetByParentIdAsync(
            int? parentId, 
            EntityStatus? status = EntityStatus.Enabled);

        Task<IEnumerable<CityResultDto>> GetProvincesAsync(
            EntityStatus? status = EntityStatus.Enabled);
    }
}
