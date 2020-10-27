using Behlog.Core.Models.Feature;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.Feature;

namespace Behlog.Repository.Feature
{
    public class WebsiteVisitRepository: BaseRepository<WebsiteVisit, long>, IWebsiteVisitRepository
    {
        public WebsiteVisitRepository(IBehlogContext context) : base(context) {
        }
    }
}
