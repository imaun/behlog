using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Behlog.Core.Contracts;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Behlog.Repository.System
{
    public class TagRepository: BaseRepository<Tag, int>, ITagRepository
    {
        
        public TagRepository(IBehlogContext context) : base(context) {
        }

        public async Task<IEnumerable<Tag>> GetByPostIdAsync(int postId) =>
            await  _dbSet
                .Include(_ => _.PostTags)
                .Where(_ => _.PostTags.Any(pt => pt.PostId == postId))
                .ToListAsync();

        public async Task<Tag> GetByTitleAsync(string title, int websiteId) {
            var tag = await FirstOrDefaultAsync(
                _ => _.Title.ToLower() == title.ToLower() 
                        && _.WebsiteId == websiteId
                );
            return tag;
        }

        public async Task<Tag> GetWebsiteTagsAsync(int websiteId) {
            throw new NotImplementedException();
        }
    }
}
