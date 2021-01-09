using Behlog.Core;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Contracts.Services.Common;
using Behlog.Core.Exceptions;
using Behlog.Core.Extensions;
using Behlog.Core.Models.Content;
using Behlog.Core.Models.Enum;
using Behlog.Core.Security;
using Behlog.Factories.Contracts.Content;
using Behlog.Services.Dto.Content;
using Mapster;
using System.Threading.Tasks;

namespace Behlog.Factories.Content
{
    public class CommentFactory : ICommentFactory
    {
        private readonly ICommentRepository _repository;
        private readonly IUserContext _userContext;
        private readonly IDateService _dateService;

        public CommentFactory(
            ICommentRepository repository,
            IUserContext userContext,
            IDateService dateService) {

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            userContext.CheckArgumentIsNull(nameof(userContext));
            _userContext = userContext;

            dateService.CheckArgumentIsNull(nameof(dateService));
            _dateService = dateService;
        }

        public async Task<Comment> MakeAsync(CreateCommentDto model) {
            model.CheckArgumentIsNull(nameof(model));
            var entity = model.Adapt<Comment>();
            entity.CreateDate = _dateService.UtcNow();
            entity.IP = AppHttpContext.IpAddress;
            entity.UserAgent = AppHttpContext.UserAgent;
            entity.SessionId = AppHttpContext.SessionId;
            entity.Status = CommentStatus.Waiting;
            if (_userContext.IsAuthenticated)
                entity.UserId = _userContext.UserId;

            return await Task.FromResult(entity);
        }

        public async Task<Comment> ApproveCommentAsync(long commentId) {
            var comment = await _repository.FindAsync(commentId);
            return await ApproveCommentAsync(comment);
        }

        public async Task<Comment> ApproveCommentAsync(Comment comment) {
            setStatus(comment, CommentStatus.Approved);
            return await Task.FromResult(comment);
        }

        public async Task<Comment> MarkAsDeletedAsync(long commentId) {
            var comment = await _repository.FindAsync(commentId);
            return await Task.FromResult(comment);
        }

        public async Task<Comment> MarkAsDeletedAsync(Comment comment) {
            setStatus(comment, CommentStatus.Deleted);
            return await Task.FromResult(comment);
        }

        public async Task<Comment> RejectCommentAsync(long commentId) {
            var comment = await _repository.FindAsync(commentId);
            return await RejectCommentAsync(comment);
        }

        public async Task<Comment> RejectCommentAsync(Comment comment) {
            setStatus(comment, CommentStatus.Rejected);
            return await Task.FromResult(comment);
        }

        #region Private Methods
        private void setStatus(Comment comment, CommentStatus status) {
            if (!_userContext.IsAuthenticated)
                throw new UserNotLoggedInException("Approving comment requires User to be logged in.");

            comment.CheckReferenceIsNull(nameof(comment));
            comment.Status = status;
            comment.ModifierUserId = _userContext.UserId;
            comment.ModifyDate = _dateService.UtcNow();
        }

        #endregion
    }
}
