using System.Threading.Tasks;
using Behlog.Core.Models.Content;

namespace Behlog.Factories.Contracts.Content {

    public interface IPostFileFactory {

        Task<PostFile> MakeAsync(File file,
            string title,
            int? postId = null,
            int? relatedFileId = null,
            int orderNum = 1);

    }
}
