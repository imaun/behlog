using Behlog.Core.Contracts;
using Behlog.Core.Models.Content;
using Behlog.Core.Contracts.Repository.Content;

namespace Behlog.Repository.Content
{
    public class CommentRepository: BaseRepository<Comment, long>, ICommentRepository
    {
        public CommentRepository(IBehlogContext context) : base(context) {
        }
    }
}
