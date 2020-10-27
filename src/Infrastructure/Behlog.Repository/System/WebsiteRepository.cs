using Behlog.Core.Models.System;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.System;

namespace Behlog.Repository.System
{
    public class WebsiteRepository: BaseRepository<Website, int>, IWebsiteRepository
    {
        public WebsiteRepository(IBehlogContext context) : base(context) {
        }

    }
}
