using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Models.System;

namespace Behlog.Core.Contracts.Repository.System
{
    public interface ITagRepository: IBaseRepository<Tag, int> {
        Task<IEnumerable<Tag>> GetByPostIdAsync(int postId);
        Task<Tag> GetByTitleAsync(string title, int websiteId);
        Task<Tag> GetWebsiteTagsAsync(int websiteId);
    }
}
