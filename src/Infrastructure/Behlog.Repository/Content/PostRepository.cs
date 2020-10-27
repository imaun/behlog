using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Content;
using Behlog.Core.Contracts.Repository.Content;

namespace Behlog.Repository.Content
{
    public class PostRepository : BaseRepository<Post, int>, IPostRepository
    {
        public PostRepository(IBehlogContext context) : base(context) {
        }

        public async Task<int> GetMaxOrderNumberAsync(int categoryId) =>
            await _dbSet
                .Where(_ => _.CategoryId == categoryId)
                .MaxAsync(_ => _.OrderNumber);
        
        public async Task<IEnumerable<Tag>> GetTagsAsync(int postId) {
            var post = await _dbSet
                .Include(_=> _.PostTags)
                .ThenInclude(_=> _.Tag)
                .FirstOrDefaultAsync(_ => _.Id == postId);

            return post?.PostTags
                .Select(_ => _.Tag)
                .ToList();
        }

        public async Task<IEnumerable<PostMeta>> GetPostMetaAsync(int postId) {
            var post = await _dbSet
                .Include(_ => _.Meta)
                .FirstOrDefaultAsync(_ => _.Id == postId);

            return post?.Meta.ToList();
        }

        public async Task<IEnumerable<File>> GetFilesAsync(int postId) {
            var post = await _dbSet
                .Include(_ => _.PostFiles)
                .ThenInclude(_ => _.File)
                .FirstOrDefaultAsync(_ => _.Id == postId);

            return post?.PostFiles
                .Select(_ => _.File)
                .ToList();
        }
    }
}
