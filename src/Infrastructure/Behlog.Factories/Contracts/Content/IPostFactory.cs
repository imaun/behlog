using Behlog.Core.Models.Content;
using Behlog.Services.Dto.Content;
using System.Threading.Tasks;

namespace Behlog.Factories.Contracts.Content {

    public interface IPostFactory {

        Task<Post> MakeAsync(PostCreateDto model);
        Task<Post> MakeAsync(PostEditDto model);
        Task<Post> MarkAsDeletedAsync(int postId);
        Task<Post> MakeSliderPostAsync(
            string title,
            string slug,
            int langId,
            bool enabled);
    }
}
