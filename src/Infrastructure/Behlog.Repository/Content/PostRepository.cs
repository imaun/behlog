using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Content;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Extensions;

namespace Behlog.Repository.Content
{
    public class PostRepository : BaseRepository<Post, int>, IPostRepository
    {
        private readonly IDateService _dateService;

        public PostRepository(
            IBehlogContext context, 
            IDateService dateService) : base(context) {
            
            dateService.CheckArgumentIsNull();
            _dateService = dateService;
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

        public async Task<(IEnumerable<Post>, int)> FrontSearchAsync(
            int websiteId, 
            string searchPhrase,
            bool paging = false,
            int skip = 1,
            int pageSize = 10) {

            var query = _dbSet
                .Include(_=> _.CreatorUser)
                .Include(_ => _.PostType)
                .Include(_ => _.Language)
                .Include(_ => _.Category)
                .Include(_ => _.PostTags)
                .ThenInclude(_ => _.Tag)
                .Where(_ => _.Status == Core.Models.Enum.PostStatus.Published)
                .Where(_ => _.PublishDate <= _dateService.UtcNow())
                .Where(_ => _.WebsiteId == websiteId)
                .Where(_ => _.Title.Contains(searchPhrase) ||
                    _.AltTitle.Contains(searchPhrase) ||
                    _.Body.Contains(searchPhrase) ||
                    _.Slug.Contains(searchPhrase) ||
                    _.Summary.Contains(searchPhrase) ||
                    _.Template.Contains(searchPhrase)
                );

            if(paging) {
                query = query.Skip(skip).Take(pageSize);
            }

            var result = await query.ToListAsync();
            var totalCount = await query.CountAsync();

            return (result, totalCount);
        }

        public async Task<Post> GetWithPostFilesAsync(int postId) {
            var post = await _dbSet
                .Include(_ => _.PostFiles)
                .ThenInclude(_ => _.File)
                .FirstOrDefaultAsync(_ => _.Id == postId);

            return post;
        }
    }
}
