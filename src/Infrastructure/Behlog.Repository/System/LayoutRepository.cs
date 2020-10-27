using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core.Models.System;
using Behlog.Core.Contracts.Repository.System;

namespace Behlog.Repository.System
{
    public class LayoutRepository: BaseRepository<Layout, int>, ILayoutRepository
    {
        public LayoutRepository(IBehlogContext context) : base(context) {
        }

        public async Task<Layout> GetByNameAsync(string name) =>
            await SingleOrDefaultAsync(_ => _.Name.ToLower() == name.ToLower());
    }
}
