using Behlog.Core.Contracts;
using Behlog.Core.Models.Content;
using Behlog.Core.Contracts.Repository.Content;

namespace Behlog.Repository.Content
{
    public class PostFileRepository: BaseRepository<PostFile, long>, IPostFileRepository
    {
        public PostFileRepository(IBehlogContext context) : base(context) {
        }
    }
}
