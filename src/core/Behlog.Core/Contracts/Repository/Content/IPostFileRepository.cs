using System.Threading.Tasks;
using Behlog.Core.Models.Content;

namespace Behlog.Core.Contracts.Repository.Content
{
    public interface IPostFileRepository: IBaseRepository<PostFile, long>
    {
    }
}
