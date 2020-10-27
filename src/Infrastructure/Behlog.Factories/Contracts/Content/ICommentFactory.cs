using Behlog.Core.Models.Content;
using Behlog.Services.Dto.Content;
using System.Threading.Tasks;

namespace Behlog.Factories.Contracts.Content
{
    public interface ICommentFactory
    {
        Task<Comment> MakeAsync(CreateCommentDto model);

        Task<Comment> ApproveCommentAsync(long commentId);

        Task<Comment> ApproveCommentAsync(Comment comment);

        Task<Comment> MarkAsDeletedAsync(long commentId);

        Task<Comment> MarkAsDeletedAsync(Comment comment);

        Task<Comment> RejectCommentAsync(long commentId);

        Task<Comment> RejectCommentAsync(Comment comment);
    }
}
