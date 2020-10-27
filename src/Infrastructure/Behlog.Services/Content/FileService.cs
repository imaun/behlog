using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.Content;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.Content;
using Behlog.Factories.Contracts.Content;
using Mapster;
using Behlog.Services.Contracts.Content;

namespace Behlog.Services.Content
{
    public class FileService: IFileService
    {
        private readonly IFileRepository _repository;
        private readonly IFileFactory _factory;

        public FileService(
            IFileRepository repository,
            IFileFactory factory) {

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;
        }

        public async Task<FileResultDto> CreateAsync(CreateFileDto model) {
            var file = await _factory.MakeAsync(model);
            await _repository.AddAndSaveAsync(file);
            return await Task.FromResult(
                file.Adapt<FileResultDto>()
                );
        }

        public async Task<FileResultDto> GetResultByIdAsync(long id) {
            var file = await _repository.FindAsync(id);
            file.CheckReferenceIsNull(nameof(file));

            return await Task.FromResult(
                file.Adapt<FileResultDto>()
                );
        }

    }
}
