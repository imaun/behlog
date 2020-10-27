using System.Threading.Tasks;
using Behlog.Core.Contracts.Repository.Feature;
using Behlog.Core.Extensions;
using Behlog.Factories.Contracts.Feature;
using Behlog.Services.Contracts.Feature;
using Behlog.Services.Dto.Feature;

namespace Behlog.Services.Feature
{
    public class PostVisitService: IPostVisitService {

        private readonly IPostVisitRepository _repository;
        private readonly IPostVisitFactory _factory;

        public PostVisitService(
            IPostVisitRepository repository,
            IPostVisitFactory factory
        ) {
            repository.CheckArgumentIsNull(nameof(repository));
            _repository = repository;

            factory.CheckArgumentIsNull(nameof(factory));
            _factory = factory;
        }


        public async Task CreateAsync(CreatePostVisitDto model) {
            var visit = await _factory.MakeAsync(model);
            await _repository.AddAndSaveAsync(visit);
        }

        public void Create(CreatePostVisitDto model) {
            var visit = _factory.Make(model);
            _repository.MarkForAdd(visit);
            _repository.SaveChanges();
        }

    }
}
