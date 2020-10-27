using System.Threading.Tasks;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.System;
using Behlog.Factories.Contracts.System;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Services.Contracts.System;

namespace Behlog.Services.System
{
    public class ErrorLogService: IErrorLogService {

        private readonly IErrorLogFactory _factory;
        private readonly IErrorLogRepository _repository;

        public ErrorLogService(
            IErrorLogFactory factory,
            IErrorLogRepository repository
        ) {
            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;

            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;
        }

        public async Task CreateAsync(CreateErrorLogDto model) {
            var entity = await _factory.MakeAsync(model);
            await _repository.AddAndSaveAsync(entity);
        }
    }
}
