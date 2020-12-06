using System.Threading.Tasks;
using System.Linq;
using Behlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Extensions;
using Behlog.Services.Extensions;
using Behlog.Factories.Contracts.Content;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Dto.Content;
using Mapster;
using Behlog.Services.Dto.Admin.Feature;
using Behlog.Services.Dto.Admin.Content;
using Behlog.Core;
using Behlog.Core.Security;
using Behlog.Core.Models.Content;
using System.Collections.Generic;
using Behlog.Core.Models.Enum;

namespace Behlog.Services.Content
{
    public class CommentService : ICommentService {

        private readonly ICommentRepository _repository;
        private readonly ICommentFactory _factory;
        private readonly IUserContext _userContext;

        public CommentService(
            ICommentRepository repository,
            ICommentFactory factory,
            IUserContext userContext) {

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;

            userContext.CheckArgumentIsNull(nameof(userContext));
            _userContext = userContext;
        }

        public async Task<AdminCommentIndexDto> GetAdminIndexAsync(AdminCommentIndexFilter filter) {
            filter.CheckArgumentIsNull(nameof(filter));

            var query = _repository
                .Query()
                .Where(_ => _.Post.WebsiteId == _userContext.WebsiteId)
                .SetFilter(filter);

            var result = new AdminCommentIndexDto();
            result.DataSource.TotalCount = await query.CountAsync();
            result.DataSource.PageIndex = filter.PageIndex;
            result.DataSource.PageSize = filter.PageSize;

            query = query
                .Skip(filter.StartIndex)
                .Take(filter.PageSize);

            var comments = await query.ToListAsync();

            await setCommentsToViewed(comments);
            await setCommentsToRead(comments);

            result.DataSource.Items = comments
                .Select(_ => _.Adapt<AdminCommentIndexItemDto>())
                .ToList();

            return await Task.FromResult(result);
        }

        public async Task<CommentResultDto> ApproveCommentAsync(long id) {
            var comment = await _repository.FindAsync(id);
            comment = await _factory.ApproveCommentAsync(comment);
            await _repository.UpdateAndSaveAsync(comment);

            return await GetResultByIdAsync(comment.Id);
        }

        public async Task<long> CreateAsync(CreateCommentDto model) {
            var comment = await _factory.MakeAsync(model);
            await _repository.AddAndSaveAsync(comment);

            return await Task.FromResult(comment.Id);
        }

        public async Task<CommentResultDto> GetResultByIdAsync(long id) {
            var comment = await _repository
                .Query()
                .Include(_ => _.User)
                .Include(_ => _.Post)
                .FirstOrDefaultAsync(_ => _.Id == id);

            comment.CheckReferenceIsNull(nameof(comment));
            var result = comment.Adapt<CommentResultDto>();

            return await Task.FromResult(result);
        }

        public async Task<CommentResultDto> RejectCommentAsync(long id) {
            var comment = await _repository.FindAsync(id);
            comment = await _factory.RejectCommentAsync(comment);
            await _repository.UpdateAndSaveAsync(comment);

            return await GetResultByIdAsync(comment.Id);
        }

        public async Task SoftDeleteAsync(long id) {
            var comment = await _repository.FindAsync(id);
            comment = await _factory.MarkAsDeletedAsync(comment);
            await _repository.UpdateAndSaveAsync(comment);
        }

        private async Task setCommentsToViewed(IList<Comment> comments) {
            foreach(var comment in comments
                .Where(_=> _.Status == CommentStatus.Waiting)
            ) {
                comment.Status = CommentStatus.Viewed;
                _repository.MarkForUpdate(comment);
            }

            await _repository.SaveChangesAsync();
        }

        private async Task setCommentsToRead(IList<Comment> comments) {
            foreach (var comment in comments
                .Where(_ => _.Status == CommentStatus.Viewed)
            ) {
                comment.Status = CommentStatus.Read;
                _repository.MarkForUpdate(comment);
            }

            await _repository.SaveChangesAsync();
        }
    }
}
