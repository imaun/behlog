using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;

namespace Behlog.Core.Contracts.Repository.System {

    public interface ICityRepository: IBaseRepository<City, int> {
        Task<IEnumerable<City>> GetProvincesAsync(EntityStatus? status = null);
        Task<IEnumerable<City>> GetByParentIdAsync(int? parentId, EntityStatus? status = null);
    }
}
