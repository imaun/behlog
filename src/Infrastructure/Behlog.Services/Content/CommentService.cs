using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Extensions;
using Behlog.Factories.Contracts.Content;
using Behlog.Services.Contracts.Content;
using Behlog.Services.Dto.Content;
using Mapster;

namespace Behlog.Services.Content
{
    public class CommentService : ICommentService {

        private readonly ICommentRepository _repository;
        private readonly ICommentFactory _factory;


        public CommentService(
            ICommentRepository repository,
            ICommentFactory factory) {

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;
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
    }
}
