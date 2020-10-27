using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Content;
using Behlog.Core.Contracts.Repository.Content;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Repository.Content
{
    public class PostMetaRepository: BaseRepository<PostMeta, int>, IPostMetaRepository
    {
        public PostMetaRepository(IBehlogContext context) : base(context) {
        }

        public async Task<PostMeta> GetPostMetaAsync(
            int postId, 
            string metaKey) {

            return await _dbSet
                .FirstOrDefaultAsync(_ => _.PostId == postId &&
                                        _.MetaKey.ToLower() == metaKey.ToLower());
        }
    }
}
