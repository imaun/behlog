using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.System;

namespace Behlog.Core.Contracts.Repository.Content
{
    public interface IPostRepository: IBaseRepository<Post, int> {
        Task<int> GetMaxOrderNumberAsync(int categoryId);
        Task<IEnumerable<Tag>> GetTagsAsync(int postId);
        Task<IEnumerable<File>> GetFilesAsync(int postId);
    }
}
