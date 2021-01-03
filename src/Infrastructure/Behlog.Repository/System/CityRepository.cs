using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Repository.System {

    public class CityRepository : BaseRepository<City, int>, ICityRepository {

        public CityRepository(IBehlogContext context): base(context) { }

        public async Task<IEnumerable<City>> GetByParentIdAsync(int? parentId, EntityStatus? status = null) {
            if (status != null)
                return await _dbSet
                    .Where(_ => _.Status == status.Value)
                    .Where(_ => _.ParentId == parentId)
                    .ToListAsync();

            return await _dbSet
                .Where(_ => _.ParentId == parentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<City>> GetProvincesAsync(EntityStatus? status = null)
            => await GetByParentIdAsync(null, status);

    }
}
