using Behlog.Core.Contracts;
using Behlog.Core.Models.Content;
using Behlog.Core.Contracts.Repository.Content;

namespace Behlog.Repository.Content
{
    public class PostLikeRepository: BaseRepository<PostLike, long>, IPostLikeRepository
    {
        public PostLikeRepository(IBehlogContext context) : base(context) {
        }
    }
}
