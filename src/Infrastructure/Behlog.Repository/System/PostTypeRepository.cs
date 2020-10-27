using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Repository.System
{
    public class PostTypeRepository: BaseRepository<PostType, int>, IPostTypeRepository
    {
        public PostTypeRepository(IBehlogContext context) : base(context) {
        }

        public async Task<PostType> GetBySlugAsync(string slug) => await
            _dbSet.FirstOrDefaultAsync(_ => _.Status == EntityStatus.Enabled &&
                                            _.Slug.ToLower() == slug.ToLower());

    }
}
