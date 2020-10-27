using System.Threading.Tasks;
using Behlog.Services.Dto.Content;

namespace Behlog.Services.Contracts.Content {

    public interface ICommentService {
        Task<long> CreateAsync(CreateCommentDto model);

        Task<CommentResultDto> GetResultByIdAsync(long id);

        Task<CommentResultDto> ApproveCommentAsync(long id);

        Task<CommentResultDto> RejectCommentAsync(long id);

        Task SoftDeleteAsync(long id);
    }
}
