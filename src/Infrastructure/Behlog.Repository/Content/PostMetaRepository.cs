using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Models.Content;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Extensions;

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

        public async Task<IEnumerable<PostMeta>> GetPostMetaWithPostAsync(
            int postId,
            int? langId = null,
            string category = null) {
            var query = _dbSet
                .Include(_ => _.Post)
                .Where(_ => _.PostId == postId);
            query = addFilter(query, langId, category);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<PostMeta>> GetPostMetaAsync(
            int postId, 
            int? langId = null, 
            string category = null) {
            
            var query = _dbSet.Where(_ => _.PostId == postId);
            query = addFilter(query, langId, category);

            return await query.ToListAsync();
        }

        private IQueryable<PostMeta> addFilter(
            IQueryable<PostMeta> query, 
            int? langId, 
            string category = null) {

            if (langId.HasValue)
                query = query.Where(_ => _.LangId == langId.Value);

            if (category.IsNotNullOrEmpty())
                query = query.Where(_ => _.Category.ToLower() == category.ToLower());

            return query;
        }
    }
}
