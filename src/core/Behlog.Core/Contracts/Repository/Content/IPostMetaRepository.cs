using System.Collections.Generic;
using System.Threading.Tasks;
using Behlog.Core.Models.Content;

namespace Behlog.Core.Contracts.Repository.Content
{
    public interface IPostMetaRepository: IBaseRepository<PostMeta, int> {
        Task<PostMeta> GetPostMetaAsync(int postId, string metaKey);
        Task<IEnumerable<PostMeta>> GetPostMetaWithPostAsync(
            int postId,
            int? langId = null,
            string category = null);
        Task<IEnumerable<PostMeta>> GetPostMetaAsync(
            int postId, 
            int? langId = null, 
            string category = null);
    }
}
