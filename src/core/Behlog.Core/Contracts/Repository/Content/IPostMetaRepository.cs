using System.Threading.Tasks;
using Behlog.Core.Models.Content;

namespace Behlog.Core.Contracts.Repository.Content
{
    public interface IPostMetaRepository: IBaseRepository<PostMeta, int> {
        Task<PostMeta> GetPostMetaAsync(int postId, string metaKey);
    }
}
