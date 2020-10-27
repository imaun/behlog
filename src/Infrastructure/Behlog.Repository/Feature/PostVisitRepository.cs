using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Models.Feature;

namespace Behlog.Repository.Feature
{
    public class PostVisitRepository: BaseRepository<PostVisit, long>, IPostVisitRepository
    {
        public PostVisitRepository(IBehlogContext context) : base(context) {
        }
    }
}
