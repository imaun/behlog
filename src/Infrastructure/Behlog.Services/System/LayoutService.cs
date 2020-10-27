using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.System;
using Behlog.Core.Extensions;
using Behlog.Factories.Contracts.System;
using Behlog.Services.Contracts.System;
using Behlog.Services.Dto.System;
using Mapster;

namespace Behlog.Services.System
{
    public class LayoutService: ILayoutService {

        private readonly ILayoutFactory _factory;
        private readonly ILayoutRepository _repo;

        public LayoutService(
            ILayoutFactory factory,
            ILayoutRepository repo
        ) {
            factory.CheckArgumentIsNull();
            _factory = factory;

            repo.CheckArgumentIsNull();
            _repo = repo;
        }

        public async Task<LayoutResultDto> CreateAsync(LayoutCreateDto model) {
            var layout = _factory.Make(model);

            await _repo.AddAndSaveAsync(layout);

            return layout.Adapt<LayoutResultDto>();
        }

        public async Task<LayoutResultDto> GetByNameAsync(string name) {
            var result = await _repo.GetByNameAsync(name);
            return result.Adapt<LayoutResultDto>();
        }
    }
}
